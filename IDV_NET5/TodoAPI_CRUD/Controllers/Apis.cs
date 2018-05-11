using System;
using System.Collections.Generic;
using System.Linq;
using IDV_NET5.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TodoAPI_CRUD.Models;

namespace TodoAPI_CRUD.Controllers
{
    [Route("api/FicheCentral")]

    public class ValuesController : Controller
    {
        public ApplicationContext context;
        public ValuesController(ApplicationContext context) { this.context = context; }



        // GET API
        //[ActionName("GetFicheCentral")]

        public List<FichierCentral> GetFicheCentral()
        {
            IEnumerable<FichierCentral> model = context.Set<FichierCentral>().ToList().Select(s => new FichierCentral
            {
                Nom = s.Nom,
                Prenom = s.Prenom,
                Login = s.Login,
                Email = s.Email,
                DateCreation = s.DateCreation,
                Abonnement = s.Abonnement,
            });
            //return View("Index", model);
            return model.ToList();
        }
        public List<Abonnements> GetAbonnements()
        {
            IEnumerable<Abonnements> listeAbonnement = context.Set<Abonnements>().ToList().Select(s => new Abonnements { });
            return listeAbonnement.ToList();
        }


        // GET
        //[HttpGet]
        //public IQueryable<FichierCentral> Get()
        //{
        //    return context.FichierCentral;
        //}

        // POST API
        //[HttpPost]
        //public IActionResult CreateUserFichier([FromBody] FichierCentral UserModel)
        //{
        //    UserModel.DateCreation = DateTime.Now;
        //    UserModel.PkProfil = 2;
        //    UserModel.UserId = Guid.NewGuid();

        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(UserModel);
        //    }
        //    try
        //    {
        //        List<FichierCentral> listAllUser = GetFicheCentral();


        //        if (listAllUser.Where(x => x.Email == UserModel.Email).Count() > 0)
        //        {
        //            return Json(new { isFailed = "cette adresse mail est déje utiliser" });
        //        }
        //        context.FichierCentral.Add(UserModel);
        //        var Save = context.SaveChanges();
        //        if (Save == 1)
        //        {
        //            return Json(new { isSuccess_Add = UserModel });
        //        }
        //        return Json(new { isFailed = UserModel });
        //    }
        //    catch (Exception e)
        //    {
        //        throw;
        //    }
        //}





        [HttpPost("{id}")]
        public IActionResult CreateAbonnementUser([FromBody] FichierCentral UserModel, long id)
        {
            UserModel.PK = id;
            UserModel.PkProfil = 2;

            Abonnements Abonnement = new Abonnements();
            Abonnement.PKAbonnement = UserModel.PkAbonnemnt;
            Abonnement.PkAbonne = UserModel.PK;
            Abonnement.DateDebut = DateTime.Now;

            if (UserModel.PkAbonnemnt == 1) { Abonnement.DateFin = DateTime.Today.AddMonths(1); Abonnement.Prix_Abonnement = 10; Abonnement.Abonnement = "abonnement-1-mois"; }
            if (UserModel.PkAbonnemnt == 2) { Abonnement.DateFin = DateTime.Today.AddYears(1); Abonnement.Prix_Abonnement = 100; Abonnement.Abonnement = "abonnement-1-ans"; }
            if (UserModel.PkAbonnemnt == 3) { Abonnement.DateFin = DateTime.Today.AddYears(2); Abonnement.Prix_Abonnement = 180; Abonnement.Abonnement = "abonnement-2-ans"; }
            UserModel.Abonnement = Abonnement.Abonnement;
            if (UserModel.PkAbonnemnt != 0)
            {
                try
                {
                    context.FichierCentral.Update(UserModel);
                    context.Abonnements.Add(Abonnement);
                    context.SaveChanges();
                    return Json(new { isSuccess_Add = UserModel });
                }
                catch (Exception e)
                {
                    throw;
                }
            }
            return Json(new { isFailed = "manque de pk abonnement pour creer un abonnement" });
        }



        // PUT api/values/5
        //[HttpPut("{id}")]
        //public IActionResult UpdateUser(long id, [FromBody] FichierCentral UserFichier)
        //{
        //    UserFichier.PK = id;
        //    try
        //    {
        //        context.FichierCentral.Update(UserFichier);
        //        return Json(new { isSuccess_Update = "ok" });
        //    }
        //    catch (Exception ex)
        //    {
        //        return Json(new { isFailed_Update = ex });
        //    }
        //}


        // delete user from CentralFile
        // DELETE API
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(long id)
        {
            FichierCentral FichierUser = context.FichierCentral.Find(id);
            if (FichierUser == null)
            {
                return NotFound();
            }
            try
            {
                context.FichierCentral.Remove(FichierUser);
                context.SaveChanges();
            }
            catch (Exception e)
            {
                throw;
            }
            return Json(new { success_delete = id });
        }
    }
}
