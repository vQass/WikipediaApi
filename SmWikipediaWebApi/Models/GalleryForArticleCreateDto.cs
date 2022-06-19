using System.ComponentModel.DataAnnotations;

namespace SmWikipediaWebApi.Models
{
    public class GalleryForArticleCreateDto
    {
        [Required]
        [MaxLength(255)]
        public string ImagePath { get; set; }
        [MaxLength(1024)]
        public string ImageDescription { get; set; }
    }
}
