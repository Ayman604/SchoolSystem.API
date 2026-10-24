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
            builder.Property(m => m.MimeType)
                .IsRequired()
                .HasMaxLength(50);
            builder.Property(m => m.FileSizeBytes)
                .IsRequired();
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
            builder.Property(m => m.DeletedAtUtc)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");


            #region Indexes 
            //builder.HasIndex(x => x.UploadedByUserId)
            //  .HasDatabaseName("IX_Media_UploadedBy");
            builder.HasIndex(x => new { x.Type, x.Category })
                .HasDatabaseName("IX_Media_TypeCategory");

            builder.HasIndex(x => x.CreatedAtUtc)
                .HasDatabaseName("IX_Media_CreatedAt");

            #endregion


        }
    }
}
