using System;
using System.Collections.Generic;
using System.Linq;
using IDV_NET5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using TodoAPI_CRUD.Models;

namespace TodoAPI_CRUD.Controllers
{
    /// <summary>
    /// Manage the User in the database
    /// </summary>

    [Route("api/FicheCentral")]

    public class ValuesController : Controller
    {
        public ApplicationContext context;
        public ValuesController(ApplicationContext context) { this.context = context; }

        public List<FichierCentral> GetFicheCentral()
        {
            IEnumerable<FichierCentral> model = context.Set<FichierCentral>().ToList().Select(s => new FichierCentral
            {
                Nom = s.Nom,
                Prenom = s.Prenom,
                Login = s.Login,
                Email = s.Email,
                DateCreation = s.DateCreation
            });
            return model.ToList();
        }


        public List<Abonnements> GetAbonnements()
        {
            IEnumerable<Abonnements> listeAbonnement = context.Set<Abonnements>().ToList().Select(s => new Abonnements { });
            return listeAbonnement.ToList();
        }


        /// <summary>
        /// Retrieve the list of user in the database
        /// </summary>
        /// <returns>The list of People</returns>
        [HttpGet]
        [ProducesResponseType(typeof(List<FichierCentral>), 200)]
        public IActionResult Get()
        {
            return Ok(context.FichierCentral.ToList());
        }


        /// <summary>
        /// Retrieve the user with the id given in parameter
        /// </summary>
        /// <param name="id">The id of the user to return</param>
        /// <returns>The Peopuserle with the id to retrieve</returns>
        /// <response code="200">If the users with the specified Id exist</response>
        /// <response code="404">If the users with the specified Id doesn't exist</response>
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(List<FichierCentral>), 200)]
        [ProducesResponseType(typeof(List<FichierCentral>), 404)]
        public IActionResult Get(int id)
        {var user = "" ;
           // var user = context.FichierCentral

                //.Include(p => p.FichierCentralID)
                //.ThenInclude(a => )

                //.Include(p => p.RealizeMovies)
                //.ThenInclude(r => r.Movie)

                //.AsNoTracking()
                //.SingleOrDefault(m => m.Id == id);
            if (user != null)
            {
                return Ok(user);
            }

            return NotFound();
        }

        /// <summary>
        /// Create a user in the database
        /// </summary>
        /// <param name="UserModel">The user to create</param>
        /// <returns>Ok if the user has been created</returns>
        [HttpPost ("CreateUserFichier")]
        public IActionResult CreateUserFichier([FromBody] FichierCentral UserModel)
        {
            UserModel.DateCreation = DateTime.Now;
            UserModel.ProfilsID = 2;
            UserModel.UserId = Guid.NewGuid();

            if (!ModelState.IsValid)
            {
                return BadRequest(UserModel);
            }
            try
            {
                List<FichierCentral> listAllUser = GetFicheCentral();
                if (listAllUser.Where(x => x.Email == UserModel.Email).Count() > 0)
                {
                    return Json(new { isFailed = "cette adresse mail est déje utiliser" });
                }
                context.FichierCentral.Add(UserModel);
                context.SaveChanges();

            }
            catch (DbUpdateException exception)
            {
                return BadRequest(new { message = exception.Message });
            }
            return Ok();
        }

        /// <summary>
        /// Create an Abonnement for user in the database
        /// </summary>
        /// <param name="UserModel">The Abonnement user to create</param>
        /// <returns>Ok if the user Abonnement has been created</returns>

        [HttpPost("CreateAbonnementUser/{id}")]
        public IActionResult CreateAbonnementUser([FromBody] FichierCentral UserModel, long id)
        {
            UserModel.FichierCentralID = id;
            UserModel.ProfilsID = 2;

            Abonnements Abonnement = new Abonnements();
            Abonnement.AbonnementsID = UserModel.AbonnementsID;
            Abonnement.pkAbonne = UserModel.FichierCentralID;
            Abonnement.DateDebut = DateTime.Now;

            if (UserModel.AbonnementsID == 1) { Abonnement.DateFin = DateTime.Today.AddMonths(1); Abonnement.Prix_Abonnement = 10; Abonnement.Abonnement = "abonnement-1-mois"; }
            if (UserModel.AbonnementsID == 2) { Abonnement.DateFin = DateTime.Today.AddYears(1); Abonnement.Prix_Abonnement = 100; Abonnement.Abonnement = "abonnement-1-ans"; }
            if (UserModel.AbonnementsID == 3) { Abonnement.DateFin = DateTime.Today.AddYears(2); Abonnement.Prix_Abonnement = 180; Abonnement.Abonnement = "abonnement-2-ans"; }

            if (UserModel.AbonnementsID != 0)
            {
                try
                {
                    context.FichierCentral.Update(UserModel);
                    context.Abonnements.Add(Abonnement);
                    context.SaveChanges();
                }
                catch (DbUpdateException exception)
                {
                    return BadRequest(new { message = exception.Message });
                }
                return Ok();
            }
            return Json(new { isFailed = "manque de pk abonnement pour creer un abonnement" });
        }


        /// <summary>
        /// Update the user specified by the id in given in parameter
        /// </summary>
        /// <param name="id">The id of the user to update</param>
        /// <param name="value">The value of the user to update</param>
        [HttpPut("{id}")]
        public IActionResult UpdateUser(long id, [FromBody] FichierCentral UserFichier)
        {
            UserFichier.FichierCentralID = id;
            try
            {
                context.FichierCentral.Update(UserFichier);
                return Ok();
            }
            catch (DbUpdateException exception)
            {
                return BadRequest(new { message = exception.Message });
            }
        }


        /// <summary>
        /// Delete a user from his id
        /// </summary>
        /// <param name="id">The id of the user to delete</param>
        /// <returns>Ok if the user has been successfully deleted</returns>
        /// <response code="200">If the user was successfully deleted</response>
        /// <response code="404">If the user to delete hasn't been found</response>
        [HttpDelete("DeleteUser/{id}")]
        public IActionResult DeleteUser(long id)
        {
            FichierCentral FichierUser = context.FichierCentral.Find(id);
            if (FichierUser == null)
            {
                return NotFound();
            }
            else
            {
                try
                {
                    context.FichierCentral.Remove(FichierUser);
                    context.SaveChanges();
                }
                catch (DbUpdateException exception)
                {
                    return BadRequest(new { message = exception.Message });
                }
                return Ok();
            }
           
        }
    }
}
