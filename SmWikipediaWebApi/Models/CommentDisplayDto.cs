namespace SmWikipediaWebApi.Models
{
    public class CommentDisplayDto
    {
        public int Id { get; set; }
        public string ArticleName { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }
        public bool IsAccepted { get; set; }

    }
}
