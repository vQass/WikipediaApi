using System.ComponentModel.DataAnnotations;

namespace SmWikipediaWebApi.Entities
{
    public class Administrator
    {
        public short Id { get; set; }
        [Required]
        [MaxLength(320)]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
