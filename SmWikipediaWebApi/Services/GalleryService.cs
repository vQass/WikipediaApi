using AutoMapper;
using SmWikipediaWebApi.Entities;
using SmWikipediaWebApi.Exceptions;
using SmWikipediaWebApi.Interfaces;
using SmWikipediaWebApi.Models;
using System.Collections.Generic;
using System.Linq;

namespace SmWikipediaWebApi.Services
{
    public class GalleryService : IGalleryService
    {
        private readonly WikipediaDbContext _dbContext;
        private readonly IMapper _mapper;

        public GalleryService(WikipediaDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }
        public int Add(GalleryCreateDto galleryCreate)
        {
            var gallery = _mapper.Map<Gallery>(galleryCreate);

            _dbContext.Galleries.Add(gallery);
            _dbContext.SaveChanges();

            var id = gallery.Id;
            return id;

        }
        public void Delete(int id)
        {
            var gallery = _dbContext.Galleries.FirstOrDefault(x => x.Id == id);

            if (gallery is null)
                throw new NotFoundException("Photo not found");

            _dbContext.Galleries.Remove(gallery);
            _dbContext.SaveChanges();
        }
        public List<GalleryDisplayDto> GetByArticleId(int id)
        {
            var article = _dbContext.Articles.FirstOrDefault(x => x.Id == id);

            if (article is null)
                throw new NotFoundException("Article not found");

            var gallery = _dbContext.Galleries.Where(x => x.ArticleId == id).ToList();

            var galleryDto = _mapper.Map<List<GalleryDisplayDto>>(gallery);

            return galleryDto;
        }

        public GalleryDisplayDto GetById(int id)
        {
            var gallery = _dbContext.Galleries.FirstOrDefault(x => x.Id == id);

            if (gallery is null)
                throw new NotFoundException("Photo not found");

            var galleryDto = _mapper.Map<GalleryDisplayDto>(gallery);

            return galleryDto;
        }

        public void Update(int id, GalleryCreateDto galleryCreate)
        {
            var gallery = _dbContext.Galleries.FirstOrDefault(x => x.Id == id);

            if (gallery is null)
                throw new NotFoundException("Photo not found");

            gallery.ArticleId = galleryCreate.ArticleId;
            gallery.ImageDescription = galleryCreate.ImageDescription;
            gallery.ImagePath = galleryCreate.ImagePath;

            _dbContext.SaveChanges();
        }
    }
}
