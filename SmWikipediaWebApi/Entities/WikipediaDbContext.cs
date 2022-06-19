using Microsoft.EntityFrameworkCore;

namespace SmWikipediaWebApi.Entities
{
    public class WikipediaDbContext : DbContext
    {
        public WikipediaDbContext(DbContextOptions<WikipediaDbContext> options) : base(options)
        {

        }

        public DbSet<Article> Articles { get; set; }
        public DbSet<Administrator> Administrators { get; set; }
        public DbSet<ArticleContent> ArticleContents { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Gallery> Galleries { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
