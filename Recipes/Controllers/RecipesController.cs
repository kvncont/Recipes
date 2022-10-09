using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Recipes.Models;
using System;
using System.Net.Mime;

namespace Recipes.Controllers {
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    [ApiController]
    public class RecipesController : ControllerBase {

        /*private string[] recipes = { "Gallo Pinto", "Tamal Asado", "Arroz con Pollo", "Rice and Beans", "Patacones" };*/

        Recipe[] recipes = {
                new() { Title = "Gallo Pinto" },
                new() { Title = "Tamal Asado" },
                new() { Title = "Arroz con Pollo" },
                new() { Title = "Rice and Beans" },
                new() { Title = "Patacones" }
            };

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetRecipes([FromQuery] int count = 5) {

            if (!recipes.Any())
                return NotFound();
            return Ok(recipes.Take(count));
        }

        [HttpPost]
        public ActionResult CreateRecipe([FromBody] Recipe newRecipe) {

            return Created("", newRecipe);
        }

        [HttpPut("{index}")]
        public ActionResult UpdateRecipe(int index) {

            if (index > recipes.Length - 1)
                return NotFound();

            return NoContent();
        }

        [HttpDelete("{index}")]
        public ActionResult DeleteRecipe(int index) {

            if (index > recipes.Length-1)
                /*return BadRequest();*/
                return NotFound();

            return NoContent();
        }
    }
}
