using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SmWikipediaWebApi.Interfaces;
using SmWikipediaWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SmWikipediaWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class GalleryController : ControllerBase
    {
        readonly IGalleryService _galleryService;
        public GalleryController(IGalleryService galleryService)
        {
            _galleryService = galleryService;
        }

        // GET: api/<CommentController>/byArticle/5
        [HttpGet("byArticle/{id}")]
        public IActionResult GetByArticleId(int id)
        {
            var gallery = _galleryService.GetByArticleId(id);

            return Ok(gallery);
        }

        // GET api/<CommentController>/byGallery/5
        [HttpGet("byGallery/{id}")]
        public IActionResult GetById(int id)
        {
            var gallery = _galleryService.GetById(id);

            return Ok(gallery);
        }

        // POST api/<CommentController>
        [HttpPost]
        public IActionResult Create([FromBody] GalleryCreateDto galleryDto)
        {
            var id = _galleryService.Add(galleryDto);

            return Created($"/api/gallery/byComment/{id}", null);
        }

        // PUT api/<CommentController>
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] GalleryCreateDto galleryDto)
        {
            _galleryService.Update(id, galleryDto);

            return Ok();
        }

        // DELETE api/<CommentController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _galleryService.Delete(id);
            return NoContent();
        }
    }
}
