using Microsoft.EntityFrameworkCore;
using School.Domain;
using School.Domain.Contracts;
using School.Domain.Entities.ContentAndMedia;
using School.Persistence.Data.DbContexts;
using System.Text.Json;

namespace School.Persistence.Data.DataSeed
{
    public class DataInitializer : IDataInitializer
    {
        private readonly SchoolDbContext _context;

        public DataInitializer(SchoolDbContext context)
        {
            _context = context;
        }
        public async Task InitializeAsync()
        {
            try
            {
                var HasMedia = await _context.Media.AnyAsync();
                var HasPosts = await _context.Posts.AnyAsync();
                var HasPostMedia = await _context.PostMedia.AnyAsync();
                if (HasMedia && HasPosts && HasPostMedia) return; // Data already exists, no need to seed
                if (!HasMedia) await SeedDataFromJson<Media, int>("Gallery.json", _context.Media);
                await _context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while initializing the database: {ex.Message}");
            }
        }

        private async Task SeedDataFromJson<T, TKey>(string fileNmae, DbSet<T> dbset) where T : BaseEntity<TKey>
        {
            var FilePath = @"..\School.Persistence\Data\DataSeed\JsonFiles\" + fileNmae;
            if (!File.Exists(FilePath))
            {
                throw new FileNotFoundException($"The file {fileNmae} was not found in the path {FilePath}");
            }

            try
            {
                #region OLD Way 
                //var jsonData = File.ReadAllText(FilePath);
                //  var entities = System.Text.Json.JsonSerializer.Deserialize<List<T>>(jsonData);

                #endregion
                var dataStream = File.OpenRead(FilePath); // Read From File
                var data = await JsonSerializer
                            .DeserializeAsync<List<T>>(dataStream,
                            options: new JsonSerializerOptions
                            { PropertyNameCaseInsensitive = true });

                if (data is not null)
                {
                    await dbset.AddRangeAsync(data); // Add Locally in DbSet
                }
            }
            catch (Exception ex)
            {
                throw new Exception($"An error occurred while seeding data from {fileNmae}: {ex.Message}");
            }
        }
    }
}
