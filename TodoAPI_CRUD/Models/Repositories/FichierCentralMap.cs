//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;

//namespace TodoAPI_CRUD.Models.Repositories
//{
//    public class FichierCentralMap
//    {
//        public FichierCentralMap(EntityTypeBuilder<FichierCentral> entityBuillder)
//        {
//            entityBuillder.HasKey(t => t.FichierCentralID);
//            entityBuillder.Property(t => t.UserId).IsRequired();
//            entityBuillder.Property(t => t.ProfilsID).IsRequired();
//            entityBuillder.Property(t => t.Nom).IsRequired();
//            entityBuillder.Property(t => t.Prenom).IsRequired();
//            entityBuillder.Property(t => t.Login).IsRequired();
//            entityBuillder.Property(t => t.Email).IsRequired();
//            entityBuillder.Property(t => t.DateCreation).IsRequired();
//            entityBuillder.Property(t => t.AbonnementsID).IsRequired();
//        }
//    }
//}
