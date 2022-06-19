using Microsoft.AspNetCore.Identity;
using SmWikipediaWebApi.Entities;
using System.Collections.Generic;
using System.Linq;

namespace SmWikipediaWebApi.Seeders
{
    public class Seeder
    {
        private readonly WikipediaDbContext _dbContext;
        private readonly IPasswordHasher<Administrator> _passwordHasher;

        public Seeder(WikipediaDbContext dbContext, IPasswordHasher<Administrator> passwordHasher)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
        }

        public void Seed()
        {
            if (_dbContext.Database.CanConnect())
            {
                if (!_dbContext.Articles.Any())
                {
                    var articles = GetArticles();
                    _dbContext.Articles.AddRange(articles);
                    _dbContext.SaveChanges();
                }
                if (!_dbContext.Administrators.Any())
                {
                    var admins = GetAdmins();
                    _dbContext.Administrators.AddRange(admins);
                    _dbContext.SaveChanges();
                }
            }
        }

        private IEnumerable<Administrator> GetAdmins()
        {
            var admin1 = new Administrator()
            {
                Email = "test@test",
            };
            admin1.Password = _passwordHasher.HashPassword(admin1, "pass123");

            var admins = new List<Administrator>()
            {
                admin1
            };
            return admins;
        }

        private IEnumerable<Article> GetArticles()
        {
            var articles = new List<Article>()
            {
                new Article()
                {
                    Name = "Test 2",
                    Gallery = new List<Gallery>()
                    {
                        new Gallery()
                        {
                        ImageDescription = "Image 3",
                        ImagePath = "TestPath3"
                        },
                        new Gallery()
                        {
                        ImageDescription = "Image 4",
                        ImagePath = "TestPath4"
                        }
                    },
                    Comment = new List<Comment>()
                    {
                        new Comment()
                        {
                            UserName = "Test user",
                            Content = "Test Article comment 3"
                        },
                        new Comment()
                        {
                            UserName = null,
                            Content = "Test Article comment 4"
                        },
                        new Comment()
                        {
                            UserName = null,
                            Content = "Test Article comment 5"
                        }
                    },
                    ArticleContent = new List<ArticleContent>()
                    {
                        new ArticleContent()
                        {
                            DisplayOrder = 1,
                            SectionName = "Article section three",
                            Content = "Test article content Test article content Test article content Test article content Test article content " +
                            "Test article content Test article content Test article content Test article content Test article content Test article content " +
                            "Test article content Test article content Test article content Test article content Test article content Test article content " +
                            "Test article content Test article content Test article content Test article content Test article content Test article content "
                        },
                        new ArticleContent()
                        {
                            DisplayOrder = 2,
                            SectionName = "Article section four",
                            Content = "Test article content Test article content Test article content Test article content Test article content " +
                            "Test article content Test article content Test article content Test article content Test article content Test article content " +
                            "Test article content Test article content Test article content Test article content Test article content Test article content " +
                            "Test article content Test article content Test article content Test article content Test article content Test article content "
                        }
                    }
                },

                new Article()
                {
                    Name = "Test 1",
                    Gallery = new List<Gallery>()
                    {
                        new Gallery()
                        {
                        ImageDescription = "Image 1",
                        ImagePath = "TestPath"
                        },
                        new Gallery()
                        {
                        ImageDescription = "Image 2",
                        ImagePath = "TestPath2"
                        }
                    },
                    Comment = new List<Comment>()
                    {
                        new Comment()
                        {
                            UserName = "Test user",
                            Content = "Test Article comment"
                        },
                        new Comment()
                        {
                            UserName = null,
                            Content = "Test Article comment 2"
                        },
                        new Comment()
                        {
                            UserName = null,
                            Content = "Test Article comment 2"
                        }
                    },
                    ArticleContent = new List<ArticleContent>()
                    {
                        new ArticleContent()
                        {
                            DisplayOrder = 1,
                            SectionName = "Article section one",
                            Content = "Test article content Test article content Test article content Test article content Test article content " +
                            "Test article content Test article content Test article content Test article content Test article content Test article content " +
                            "Test article content Test article content Test article content Test article content Test article content Test article content " +
                            "Test article content Test article content Test article content Test article content Test article content Test article content "
                        },
                        new ArticleContent()
                        {
                            DisplayOrder = 2,
                            SectionName = "Article section two",
                            Content = "Test article content Test article content Test article content Test article content Test article content " +
                            "Test article content Test article content Test article content Test article content Test article content Test article content " +
                            "Test article content Test article content Test article content Test article content Test article content Test article content " +
                            "Test article content Test article content Test article content Test article content Test article content Test article content "
                        }
                    }
                }
            };
            return articles;
        }
    }
}
