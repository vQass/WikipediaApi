using System.Collections.Generic;

namespace SmWikipediaWebApi.Models
{
    public class ArticleDisplayDto
    {
        public string Name { get; set; }
        public List<ArticleContentForArticleDto> ArticleContent { get; set; }
        public List<GalleryForArticleDto> Gallery { get; set; }
        public List<CommentForArticleDto> Comment { get; set; }
    }
}
