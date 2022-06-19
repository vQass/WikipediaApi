using SmWikipediaWebApi.Models;
using System.Collections.Generic;

namespace SmWikipediaWebApi.Interfaces
{
    public interface ICommentService
    {
        public List<CommentDisplayDto> GetByArticleId(int id);
        public CommentDisplayDto GetById(int id);
        public void Accept(int id);
        public int Add(CommentCreateDto commentDto);
        public void Delete(int id);
        List<CommentDisplayDto> GetAllComments();
    }
}
