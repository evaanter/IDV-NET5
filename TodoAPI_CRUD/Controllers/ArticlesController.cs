using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoAPI_CRUD.Models;

namespace TodoAPI_CRUD.Controllers
{
    /// <summary>
    /// Manage the Article in the database
    /// </summary>

    [Produces("application/json")]
    [Route("api/Articles")]
    public class ArticlesController : Controller
    {

        public ApplicationContext context;
        public ArticlesController(ApplicationContext context) { this.context = context; }
        
        /// <summary>
        /// Retrieve all the Articles in the database
        /// </summary>
        /// <returns>The list of Articles</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<Articles>), 200)]
        public IActionResult Get()
        {
            return Ok(context.Articles.ToList());
        }

        /// <summary>
        /// Search a Movie by his title
        /// </summary>
        /// <param name="q">The text to search in title</param>
        /// <returns>The list of articles corresponding to this article</returns>
        [HttpGet("search")]
        [ProducesResponseType(typeof(List<Articles>), 200)]
        [ProducesResponseType(typeof(List<Articles>), 404)]
        public IActionResult SearchMovie([FromQuery] string q)
        {
            var articles = context.Articles
                .Where(m => m.TitreArticle.ToLower().Replace(" ", string.Empty).Contains(
                    q.Trim().ToLower().Replace(" ", string.Empty)))
                .ToList();
            if (articles.Count == 0)
                return NotFound();
            return Ok(articles);
        }

        /// <summary>
        /// Create a Movie in the database
        /// </summary>
        /// <param name="article">The Movie to create</param>
        /// <returns>Ok if the Movie is created</returns>
        /// <response code="200">If the Movie was successfully created</response>
        /// <response code="400">If the Movie hasn't been created</response>
        [HttpPost, Authorize]
        public IActionResult Post([FromBody]Articles article)
        {
            context.Articles.Add(article);
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException exception)
            {
                return BadRequest(new { message = exception.Message });
            }

            return Ok();
        }


        // TODO
        /// <summary>
        /// Update the Articles specified by the id in given in parameter
        /// </summary>
        /// <param name="id">The id of the Articles to update</param>
        /// <param name="value">The value of the Articles to update</param>
        [HttpPut("{id}"), Authorize]
        public void Put(int id, [FromBody]Articles value)
        {

        }

        /// <summary>
        /// Delete a Articles from his id
        /// </summary>
        /// <param name="id">The id of the Articles to delete</param>
        /// <returns>Ok if the Articles has been successfully deleted</returns>
        /// <response code="200">If the Articles was successfully deleted</response>
        /// <response code="404">If the Articles to delete hasn't been found</response>
        [HttpDelete("{id}"), Authorize]
        public IActionResult Delete(int id)
        {
            var article = context.Articles.FirstOrDefault(m => m.ArticlesID == id);

            if (article == null)
                return NotFound();

            context.Articles.Remove(article);
            context.SaveChanges();
            return Ok();

        }

    }
}
