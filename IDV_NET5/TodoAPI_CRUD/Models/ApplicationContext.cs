using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TodoAPI_CRUD.Models.Repositories;
using IDV_NET5.Models;

namespace TodoAPI_CRUD.Models
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions opts) : base(opts) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var config = modelBuilder.Entity<FichierCentral>();
            config.ToTable("FichierCentral");
            new FichierCentralMap(config);

            //base.OnModelCreating(modelBuilder);
            //var configAbonnement = modelBuilder.Entity<Abonnements>();
            //configAbonnement.ToTable("Abonnements");
            //new AbonnementsMap(configAbonnement);
        }

        public DbSet<FichierCentral> FichierCentral { get; set; }
        public DbSet<Abonnements> Abonnements { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }
    }

}
