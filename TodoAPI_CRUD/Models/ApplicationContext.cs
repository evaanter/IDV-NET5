using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

using IDV_NET5.Models;
//using TodoAPI_CRUD.Models.Repositories;

namespace TodoAPI_CRUD.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions opts) : base(opts) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //var config = modelBuilder.Entity<FichierCentral>();
            //config.ToTable("FichierCentral");
            //new FichierCentralMap(config);
        }

        public DbSet<FichierCentral> FichierCentral { get; set; }
        public DbSet<Abonnements> Abonnements { get; set; }
        public DbSet<Articles>Articles { get; set; }
        public DbSet<Videos> Videos { get; set; }
        public DbSet<Images> Images { get; set; }
        public DbSet<CategoriesMedia> CategoriesMedia { get; set; }
        public DbSet<NotesEtCommentaires> NotesEtCommentaires { get; set; }
        public DbSet<Profils> Profils { get; set; }

     protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    }

}
