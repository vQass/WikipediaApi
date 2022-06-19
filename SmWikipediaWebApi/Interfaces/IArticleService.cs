using SmWikipediaWebApi.Models;
using System;
using System.Collections.Generic;

namespace SmWikipediaWebApi.Interfaces
{
    public interface IArticleService
    {
        public IEnumerable<Object> GetAll();
        public ArticleDisplayDto GetById(short id);
        public short Create(ArticleCreateDto articleDto);
        public void Delete(short id);
        public void Update(short id, ArticleCreateDto articleDto);
    }
}
