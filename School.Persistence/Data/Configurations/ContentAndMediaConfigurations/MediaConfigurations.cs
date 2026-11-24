using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities.ContentAndMedia;

namespace School.Persistence.Data.Configurations.ContentAndMediaConfigurations
{
    public class MediaConfigurations : IEntityTypeConfiguration<Media>
    {
        public void Configure(EntityTypeBuilder<Media> builder)
        {
            builder.ToTable("Media");
            builder.HasKey(m => m.Id);

            builder.Property(m => m.FileName)
                .IsRequired()
                .HasMaxLength(255);
            builder.Property(m => m.FilePath)
                .IsRequired()
                .HasMaxLength(500);


            builder.Property(m => m.AltText)
                .IsRequired()
                .HasMaxLength(500);
            builder.Property(m => m.Type)
                .IsRequired();
            builder.Property(m => m.Category)
                .IsRequired();
            builder.Property(m => m.IsDeleted)
                .IsRequired()
                .HasDefaultValue(false);
            builder.Property(m => m.CreatedAtUtc)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");


            #region Indexes 

            builder.HasIndex(x => new { x.Category, x.Type })
                .HasDatabaseName("IX_Media_CategoryType");

            builder.HasIndex(x => x.CreatedAtUtc)
                .IsDescending()
                .HasDatabaseName("IX_Media_CreatedAt");

            #endregion


        }
    }
}
