using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities.ContentAndMedia;

namespace School.Persistence.Data.Configurations.ContentAndMediaConfigurations
{
    public class PostConfigurations : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Posts");

            builder.HasKey(x => x.Id);


            #region Properties Configurations 
            builder.Property(x => x.Title)
                .IsRequired()
                .HasMaxLength(250);

            builder.Property(x => x.Content)
                .IsRequired();

            builder.Property(x => x.Type)
                .IsRequired();

            builder.Property(x => x.IsPublished)
                .HasDefaultValue(true);

            builder.Property(x => x.CreatedAtUtc)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");
            #endregion

            #region Indexes 
            builder.HasIndex(x => x.Type)
                   .HasDatabaseName("IX_Post_Type");
            #endregion
        }
    }
}
