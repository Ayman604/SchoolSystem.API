using System.ComponentModel.DataAnnotations;

namespace School.Domain.Entities.ContentAndMedia
{
    public class PostMedia
    {

        public int PostId { get; set; }
        [Key]
        public int MediaId { get; set; }

        // Navigation Properties
        // public Post Post { get; set; } = default!;

        public Media Media { get; set; } = default!;


    }
}
