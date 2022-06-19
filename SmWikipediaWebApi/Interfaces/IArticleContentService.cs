using SmWikipediaWebApi.Models;
using System.Collections.Generic;

namespace SmWikipediaWebApi.Interfaces
{
    public interface IArticleContentService
    {
        public List<ArticleContentDisplayDto> GetByArticleId(int id);
        public ArticleContentDisplayDto GetById(int id);
        public void Update(int id, ArticleContentCreateDto articleContentDto);
        public int Add(ArticleContentCreateDto articleContentDto);
        public void Delete(int id);
    }
}
