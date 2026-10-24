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

            #region Properties Configurations
            builder.Property(x => x.MediaRole)
                .IsRequired();

            builder.Property(x => x.DisplayOrder)
                .HasDefaultValue(0);
            #endregion

            #region Relationships Configurations


            builder.HasOne(PM => PM.RelatedMedia)
                .WithOne(M => M.OwnerPost)
                .HasForeignKey<PostMedia>(PM => PM.MediaId)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(PM => PM.RelatedPost)
                .WithMany(P => P.MediaAttachments!)
                .HasForeignKey(PM => PM.PostId)
                .IsRequired()
                .OnDelete(DeleteBehavior.NoAction);


            #endregion
        }


    }
}