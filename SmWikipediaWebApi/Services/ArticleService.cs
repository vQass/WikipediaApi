using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmWikipediaWebApi.Entities;
using SmWikipediaWebApi.Exceptions;
using SmWikipediaWebApi.Interfaces;
using SmWikipediaWebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SmWikipediaWebApi.Services
{
    public class ArticleService : IArticleService
    {
        readonly IMapper _mapper;
        readonly WikipediaDbContext _dbContext;
        public ArticleService(IMapper mapper, WikipediaDbContext dbContext)
        {
            _mapper = mapper;
            _dbContext = dbContext;
        }

        public IEnumerable<Object> GetAll()
        {
            var articleList = _dbContext.Articles.Select(s => new { s.Id, s.Name }).ToList();
            return articleList;
        }

        public ArticleDisplayDto GetById(short id)
        {
            var article = _dbContext.Articles.Where(x => x.Id == id)
                .Include(x => x.ArticleContent)
                .Include(x => x.Comment.Where(x => x.IsAccepted == true))
                .Include(x => x.Gallery)
                .FirstOrDefault();

            if (article is null)
                throw new NotFoundException("Article not found");

            article.ArticleContent = article.ArticleContent.OrderBy(x => x.DisplayOrder).ToList();

            var articleDto = _mapper.Map<ArticleDisplayDto>(article);
            return articleDto;
        }

        public short Create(ArticleCreateDto articleDto)
        {
            var article = _mapper.Map<Article>(articleDto);
            
            _dbContext.Add(article);
            _dbContext.SaveChanges();

            return article.Id;
        }

        public void Delete(short id)
        {
            var article = _dbContext.Articles.FirstOrDefault(x => x.Id == id);

            if (article is null)
                throw new NotFoundException("Article not found");

            _dbContext.Articles.Remove(article);
            _dbContext.SaveChanges();
        }

        public void Update(short id, ArticleCreateDto articleDto)
        {
            var article = _dbContext.Articles
                .Include(x => x.ArticleContent)
                .Include(x => x.Gallery)
                .FirstOrDefault(x => x.Id == id);

            if (article is null)
                throw new NotFoundException("Article not found");

            var gallery = _mapper.Map<List<Gallery>>(articleDto.Gallery);
            var articleContents = _mapper.Map<List<ArticleContent>>(articleDto.ArticleContent);

            article.Name = articleDto.Name;
            article.ArticleContent = articleContents;
            article.Gallery = gallery;

            _dbContext.SaveChanges();
        }
    }
}
