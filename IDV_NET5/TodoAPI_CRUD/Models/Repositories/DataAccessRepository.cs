using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoAPI_CRUD.Models.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace TodoAPI_CRUD.Models.Repositories
{
    public interface IDataAccess<TEntity, FichierCentral> where TEntity : class
    {
        int AddFiche(TEntity b);
        int DeleteFiche(FichierCentral id);
        IEnumerable<TEntity> GetFiches();
        TEntity GetFiche(FichierCentral id);
        // int UpdateFiche(FichierCentral id, TEntity b);

    }
    public class DataAccessRepository : IDataAccess<FichierCentral, int>
    {
        ApplicationContext ctx;

        public DataAccessRepository(ApplicationContext c)
        {
            ctx = c;
        }

        public int AddFiche(FichierCentral Fiche)
        {
            ctx.FichierCentral.Add(Fiche);
            int res = ctx.SaveChanges();
            return res;
        }

        public int DeleteFiche(int id)
        {
            int res = 0;
            var fiche = ctx.FichierCentral.FirstOrDefault(b => b.PK == id);
            if (fiche != null)
            {
                ctx.FichierCentral.Remove(fiche);
                res = ctx.SaveChanges();
            }
            return res;
        }

        public FichierCentral GetFiche(int id)
        {
            var fiche = ctx.FichierCentral.FirstOrDefault(b => b.PK == id);
            return fiche;
        }

        public IEnumerable<FichierCentral> GetFiches()
        {
            var fiches = ctx.FichierCentral.ToList();
            return fiches;
        }

        //public int UpdateFiche(int id, FichierCentral fichelecteur)
        //{
        //    int res = 0;
        //    var fiche = ctx.FichierCentrals.Add(fichelecteur);
        //    if (fiche != null)
        //    {
        //        fiche.
        //    }

        //}
    }
}



