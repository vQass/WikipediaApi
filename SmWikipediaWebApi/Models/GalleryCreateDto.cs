using System.ComponentModel.DataAnnotations;

namespace SmWikipediaWebApi.Models
{
    public class GalleryCreateDto
    {
        [Required]
        public short ArticleId { get; set; }
        [Required]
        [MaxLength(255)]
        public string ImagePath { get; set; }
        [MaxLength(1024)]
        public string ImageDescription { get; set; }
    }
}