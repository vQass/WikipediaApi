using System.ComponentModel.DataAnnotations;

namespace SmWikipediaWebApi.Models
{
    public class CommentCreateDto
    {
        [Required]
        public short ArticleId { get; set; }
        [MaxLength(64)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(2048)]
        public string Content { get; set; }
    }
}
