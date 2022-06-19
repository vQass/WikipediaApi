using System.ComponentModel.DataAnnotations;

namespace SmWikipediaWebApi.Models
{
    public class ArticleContentForArticleCreateDto
    {
        public short DisplayOrder { get; set; }
        [Required]
        [MaxLength(255)]
        public string SectionName { get; set; }
        [Required]
        public string Content { get; set; }
    }
}
