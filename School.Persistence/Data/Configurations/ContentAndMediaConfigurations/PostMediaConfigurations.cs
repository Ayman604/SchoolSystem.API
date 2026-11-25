using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using School.Domain.Entities.ContentAndMedia;

namespace School.Persistence.Data.Configurations.ContentAndMediaConfigurations
{
    public class PostMediaConfigurations : IEntityTypeConfiguration<PostMedia>
    {
        public void Configure(EntityTypeBuilder<PostMedia> builder)
        {
            builder.ToTable("PostMedia");

            builder.HasKey(x => x.MediaId);

            builder.HasOne<Post>()
                  .WithMany(P => P.MediaAttachments)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Cascade);


            builder.HasOne(pm => pm.Media)
                .WithOne()
                .HasForeignKey<PostMedia>(x => x.MediaId)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}