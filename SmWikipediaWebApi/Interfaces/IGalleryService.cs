using SmWikipediaWebApi.Models;
using System.Collections.Generic;


namespace SmWikipediaWebApi.Interfaces
{
    public interface IGalleryService
    {
        public List<GalleryDisplayDto> GetByArticleId(int id);
        public GalleryDisplayDto GetById(int id);
        public void Update(int id, GalleryCreateDto galleryDto);
        public int Add(GalleryCreateDto galleryDto);
        public void Delete(int id);
    }
}
