using Microsoft.EntityFrameworkCore;
using School.Domain.Entities.ContentAndMedia;
using System.Reflection;

namespace School.Persistence.Data.DbContexts
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions<SchoolDbContext> options)
            : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            // modelBuilder.ApplyConfigurationsFromAssembly(typeof(SchoolDbContext).Assembly);
        }
        #region DbSets 
        public DbSet<Post> Posts { get; set; }
        public DbSet<Media> Media { get; set; }
        public DbSet<PostMedia> PostMedia { get; set; }

        #endregion
    }
}
