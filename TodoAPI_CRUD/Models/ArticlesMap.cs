//using IDV_NET5.Models;
//using Microsoft.EntityFrameworkCore.Metadata.Builders;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace TodoAPI_CRUD.Models
//{
//    public class ArticlesMap
//    {
//        public ArticlesMap(EntityTypeBuilder <Articles> entityBuillder)
//        {
           
//            entityBuillder.HasKey(t => t.Id);
//            entityBuillder.Property(t => t.PkRedacteur).IsRequired();
//            entityBuillder.Property(t => t.TitreArticle).IsRequired();
//            entityBuillder.Property(t => t.TextArticle).IsRequired();
//            entityBuillder.Property(t => t.DateCreation).IsRequired();
//            entityBuillder.Property(t => t.LoginCreation).IsRequired();
//            entityBuillder.Property(t => t.DateModification).IsRequired();
//            entityBuillder.Property(t => t.LoginModification).IsRequired();
//            entityBuillder.Property(t => t.PhraseAcroche).IsRequired();
//            entityBuillder.Property(t => t.VideoUrl).IsRequired();
//            entityBuillder.Property(t => t.ImageUrl).IsRequired();
//            entityBuillder.Property(t => t.PkCategorie).IsRequired();
//            entityBuillder.Property(t => t.PkCategorieMedia).IsRequired();
//        }
//    }
//}
