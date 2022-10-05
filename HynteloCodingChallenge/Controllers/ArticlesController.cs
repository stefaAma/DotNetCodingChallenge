using HynteloCodingChallenge.Models;
using HynteloCodingChallenge.Repos.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace HynteloCodingChallenge.Controllers
{
    [Route("api/articles")]
    public class ArticlesController : Controller
    {
        private IRepository _repository;
        public ArticlesController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public IActionResult Create (Article newArticle)
        {
            if (!ModelState.IsValid) 
                return BadRequest("Something went wrong when creating the article!");

            try
            {
                _repository.Create(newArticle);
                HttpContext.Response.Headers.Add("Location", $"/api/articles/{newArticle.Id}");
                HttpContext.Response.StatusCode = 201;
                return Json(newArticle);
            } catch(Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete]
        public IActionResult Delete (Guid id)
        {
            if (!_repository.Delete(id))
                return NotFound("Article not found!");

            return Ok();
        }

        [HttpPut]
        public IActionResult Update (Guid Id, [FromBody]Article existingArticle)
        {
            if (!ModelState.IsValid)
                return BadRequest("Something went wrong when updating the article!");

            existingArticle.Id = Id;
            try
            {
                if (!_repository.Update(existingArticle))
                    return NotFound("Article not found!");
                return Ok();
            } catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Read(Guid Id)
        {
            Article? article = _repository.Get(Id);
            if (article == null)
                return NotFound("Article not found!");
            return Json(article);
        }
    }
}
