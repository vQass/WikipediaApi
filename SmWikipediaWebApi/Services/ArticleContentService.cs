using AutoMapper;
using SmWikipediaWebApi.Entities;
using SmWikipediaWebApi.Exceptions;
using SmWikipediaWebApi.Interfaces;
using SmWikipediaWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmWikipediaWebApi.Services
{
    public class ArticleContentService : IArticleContentService
    {
        private readonly WikipediaDbContext _dbContext;
        private readonly IMapper _mapper;

        public ArticleContentService(WikipediaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public int Add(ArticleContentCreateDto articleContentDto)
        {
            var articleContent = _mapper.Map<ArticleContent>(articleContentDto);

            _dbContext.ArticleContents.Add(articleContent);
            _dbContext.SaveChanges();

            var id = articleContent.Id;
            return id;
        }
        public void Delete(int id)
        {
            var articleContent = _dbContext.ArticleContents.FirstOrDefault(x => x.Id == id);

            if (articleContent is null)
                throw new NotFoundException("Article content not found");

            _dbContext.ArticleContents.Remove(articleContent);
            _dbContext.SaveChanges();
        }
        public List<ArticleContentDisplayDto> GetByArticleId(int id)
        {
            var article = _dbContext.Articles.FirstOrDefault(x => x.Id == id);

            if (article is null)
                throw new NotFoundException("Article not found");

            var articleContents = _dbContext.ArticleContents.Where(x => x.ArticleId == id).OrderBy(x => x.DisplayOrder).ToList();

            var articleContentsDto = _mapper.Map<List<ArticleContentDisplayDto>>(articleContents);

            return articleContentsDto;
        }

        public ArticleContentDisplayDto GetById(int id)
        {
            var articleContent = _dbContext.ArticleContents.FirstOrDefault(x => x.Id == id);

            if (articleContent is null)
                throw new NotFoundException("Article content not found");

            var articleContentDto = _mapper.Map<ArticleContentDisplayDto>(articleContent);

            return articleContentDto;
        }

        public void Update(int id, ArticleContentCreateDto articleContentDto)
        {
            var articleContent = _dbContext.ArticleContents.FirstOrDefault(x => x.Id == id);

            if (articleContent is null)
                throw new NotFoundException("Article content not found");

            articleContent.ArticleId = articleContentDto.ArticleId;
            articleContent.Content = articleContentDto.Content;
            articleContent.SectionName = articleContentDto.SectionName;

            _dbContext.SaveChanges();
        }
    }
}
