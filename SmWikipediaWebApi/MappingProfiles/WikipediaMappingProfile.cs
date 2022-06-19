using AutoMapper;
using SmWikipediaWebApi.Entities;
using SmWikipediaWebApi.Models;

namespace SmWikipediaWebApi.MappingProfiles
{
    public class WikipediaMappingProfile : Profile
    {
        public WikipediaMappingProfile()
        {
            CreateMap<ArticleCreateDto, Article>();
            CreateMap<Article, ArticleDisplayDto>();

            CreateMap<ArticleContentCreateDto, ArticleContent>();
            CreateMap<ArticleContent, ArticleContentDisplayDto>().ForMember(x => x.ArticleName, c => c.MapFrom(s => s.Article.Name));

            CreateMap<ArticleContent, ArticleContentForArticleDto>();

            CreateMap<ArticleContentForArticleCreateDto, ArticleContent>();

            CreateMap<GalleryCreateDto, Gallery>();
            CreateMap<Gallery, GalleryDisplayDto>().ForMember(x => x.ArticleName, c => c.MapFrom(s => s.Article.Name));

            CreateMap<Gallery, GalleryForArticleDto>();

            CreateMap<GalleryForArticleCreateDto, Gallery>();

            CreateMap<CommentCreateDto, Comment>();
            CreateMap<Comment, CommentDisplayDto>().ForMember(x => x.ArticleName, c => c.MapFrom(s => s.Article.Name));

            CreateMap<Comment, CommentForArticleDto>();

            CreateMap<AdministratorCreateDto, Administrator>();
        }
    }
}
