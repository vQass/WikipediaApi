using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmWikipediaWebApi.Models
{
    public class ArticleCreateDto
    {
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public List<ArticleContentForArticleCreateDto> ArticleContent { get; set; }
        public List<GalleryForArticleCreateDto> Gallery { get; set; }
    }
}
