using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SmWikipediaWebApi.Entities;
using SmWikipediaWebApi.Exceptions;
using SmWikipediaWebApi.Interfaces;
using SmWikipediaWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmWikipediaWebApi.Services
{
    public class CommentService : ICommentService
    {
        private readonly WikipediaDbContext _dbContext;
        private readonly IMapper _mapper;

        public CommentService(WikipediaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public int Add(CommentCreateDto commentCreate)
        {
            var comment = _mapper.Map<Comment>(commentCreate);

            _dbContext.Comments.Add(comment);
            _dbContext.SaveChanges();

            var id = comment.Id;

            return id;
        }

        public void Accept(int id)
        {
            var comment = _dbContext.Comments.FirstOrDefault(x => x.Id == id);

            if (comment is null)
                throw new NotFoundException("Comment not found");

            comment.IsAccepted = true;
            _dbContext.SaveChanges();
        }

        public void Delete(int id)
        {
            var comment = _dbContext.Comments.FirstOrDefault(x => x.Id == id);

            if (comment is null)
                throw new NotFoundException("Comment not found");

            _dbContext.Remove(comment);
            _dbContext.SaveChanges();
        }

        public List<CommentDisplayDto> GetByArticleId(int id)
        {
            var article = _dbContext.Articles.FirstOrDefault(x => x.Id == id);

            if (article is null)
                throw new NotFoundException("Article not found");

            var comments = _dbContext.Comments.Include(b => b.Article).Where(x => x.ArticleId == id).ToList();

            var commentsDto = _mapper.Map<List<CommentDisplayDto>>(comments);

            return commentsDto;
        }

        public CommentDisplayDto GetById(int id)
        {
            var comment = _dbContext.Comments.Include(b => b.Article).FirstOrDefault(x => x.Id == id);

            if (comment is null)
                throw new NotFoundException("Comment not found");

            var commentDto = _mapper.Map<CommentDisplayDto>(comment);

            return commentDto;
        }

        public List<CommentDisplayDto> GetAllComments()
        {
            var comments = _dbContext.Comments.Include(b => b.Article).OrderBy(x => x.IsAccepted).ToList();

            var commentsDto = _mapper.Map<List<CommentDisplayDto>>(comments);

            return commentsDto;
        }
    }
}
