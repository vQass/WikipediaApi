using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace SmWikipediaWebApi.Entities
{
    public class Comment
    {
        public short Id { get; set; }
        public short ArticleId { get; set; }
        [DefaultValue(false)]
        public bool IsAccepted { get; set; }
        [MaxLength(64)]
        public string UserName { get; set; }
        [Required]
        [MaxLength(2048)]
        public string Content { get; set; }
        public virtual Article Article { get; set; }
    }
}
