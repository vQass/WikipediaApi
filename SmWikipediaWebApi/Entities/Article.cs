using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SmWikipediaWebApi.Entities
{
    public class Article
    {
        public short Id { get; set; }
        [Required]
        [MaxLength(255)]
        public string Name { get; set; }
        public List<ArticleContent> ArticleContent { get; set; }
        public List<Gallery> Gallery { get; set; }
        public List<Comment> Comment { get; set; }
    }
}
