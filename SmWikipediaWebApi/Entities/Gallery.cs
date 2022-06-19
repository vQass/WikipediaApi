using System.ComponentModel.DataAnnotations;

namespace SmWikipediaWebApi.Entities
{
    public class Gallery
    {
        public short Id { get; set; }
        public short ArticleId { get; set; }
        [Required]
        [MaxLength(255)]
        public string ImagePath { get; set; }
        [MaxLength(1024)]
        public string ImageDescription { get; set; }
        public virtual Article Article { get; set; }
    }
}
