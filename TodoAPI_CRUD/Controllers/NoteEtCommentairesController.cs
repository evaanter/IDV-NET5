using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IDV_NET5.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TodoAPI_CRUD.Models;

namespace TodoAPI_CRUD.Controllers
{
    [Produces("application/json")]
    [Route("api/NoteEtCommentaires")]
    public class NoteEtCommentairesController : Controller
    {
        public ApplicationContext context;
        private readonly UserManager<FichierCentral> _user;
        public NoteEtCommentairesController(ApplicationContext context, UserManager<FichierCentral> _user)
        {
            this.context = context;
            this._user = _user;
        }



        // GET: api/NoteEtCommentaires/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        /// <summary>
        /// Create a comment for a Article
        /// </summary>
        /// <param name="comment">The Article to add</param>
        /// <returns>Ok if the comment has been successfully created</returns>
        /// <response code="200">If the comment has been created</response>
        /// <response code="400">If the comment couldn't be created</response>
        [HttpPost, Authorize]
        public async Task<IActionResult> Post([FromBody] NotesEtCommentaires comment)
        {
            if (comment.Commentaire == null || comment.Commentaire.Trim().Equals(""))
                return BadRequest();

            var user = await _user.GetUserAsync(HttpContext.User);

            comment.FichierCentralID = user.FichierCentralID;

            context.NotesEtCommentaires.Add(comment);
            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException dbUpdateException)
            {
                return BadRequest(new { message = dbUpdateException.Message });
            }

            return Ok();
        }


        /// <summary>
        /// Update a Comment in a Movie
        /// </summary>
        /// <param name="id">The id of the comment to update</param>
        /// <param name="comment">The comment to update</param>
        /// <returns>Ok if the comment has been updated</returns>
        /// <response code="200">If the Comment has been updated</response>
        /// <response code="400">If the Comment couldn't be created</response>
        /// <response code="403">If the current User is not the owner of the Comment</response>
        /// <response code="404">If the Comment doesn't exist</response>
        [HttpPut("{id}"), Authorize]
        public async Task<IActionResult> Put(int id, [FromBody] NotesEtCommentaires comment)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var user = await _user.GetUserAsync(HttpContext.User);

            var existingComment = context.NotesEtCommentaires.Find(id);

            if (existingComment == null)
                return NotFound();


            if (existingComment.FichierCentralID != user.FichierCentralID)
                return Forbid();

            existingComment.Commentaire = comment.Commentaire;
            existingComment.DateCreation = comment.DateCreation;

            try
            {
                context.SaveChanges();
            }
            catch (DbUpdateException dbUpdateException)
            {
                return BadRequest(new { message = dbUpdateException.Message });
            }

            return Ok();
        }


        /// <summary>
        /// Delete the Comment by the given id
        /// </summary>
        /// <param name="id">The id of the Comment to delete</param>
        /// <returns>Ok if the Comment has been successfully deleted</returns>
        /// <response code="200">If the Comment has been deleted</response>
        /// <response code="403">If the current User is not the owner of the Comment</response>
        /// <response code="404">If the Comment doesn't exist</response>
        [HttpDelete("{id}"), Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var user = await _user.GetUserAsync(HttpContext.User);

            var comment = context.NotesEtCommentaires.Find(id);

            if (comment == null)
                return NotFound();

            if (user.FichierCentralID != comment.FichierCentralID)
                return Forbid();

            context.NotesEtCommentaires.Remove(comment);
            context.SaveChanges();
            return Ok();

        }

    }
}
