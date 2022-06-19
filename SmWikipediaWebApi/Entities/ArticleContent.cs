using System.ComponentModel.DataAnnotations;

namespace SmWikipediaWebApi.Entities
{
    public class ArticleContent
    {
        public ArticleContent()
        {

        }
        public ArticleContent(ArticleContent articleContent)
        {
            Id = articleContent.Id;
            ArticleId = articleContent.ArticleId;
            SectionName = articleContent.SectionName;
            Content = articleContent.Content;
            Article = articleContent.Article;
        }

        public short Id { get; set; }
        public short ArticleId { get; set; }
        [Required]
        [MaxLength(255)]
        public short DisplayOrder { get; set; }
        public string SectionName { get; set; }
        [Required]
        public string Content { get; set; }
        public virtual Article Article { get; set; }
    }
}
