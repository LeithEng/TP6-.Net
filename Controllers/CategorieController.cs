using Microsoft.AspNetCore.Mvc;
using WebApplication2.Models;
using WebApplication2.DTOs;
using WebApplication2.Services;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorieController : ControllerBase
    {
        private readonly ICategorieService _categorieService;

        public CategorieController(ICategorieService categorieService)
        {
            _categorieService = categorieService;
        }

        // GET: api/categorie
        [HttpGet]
        public IActionResult Get()
        {
            var categories = _categorieService.Index();
            return Ok(categories);
        }

        // POST: api/categorie
        [HttpPost]
        public IActionResult Post([FromBody] CategorieDto categorie)
        {
            if (categorie == null)
                return BadRequest();

            var createdCategorie = _categorieService.Create(categorie);
            return CreatedAtAction(nameof(Get), new { id = createdCategorie.Id }, createdCategorie);
        }

        // PUT: api/categorie/{id}
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] CategorieDto categorie)
        {
            if (categorie == null)
                return BadRequest();

            var updatedCategorie = _categorieService.Edit(categorie, id);
            return Ok(updatedCategorie);
        }

        // DELETE: api/categorie/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _categorieService.Delete(id);
            return NoContent();
        }
    }
}