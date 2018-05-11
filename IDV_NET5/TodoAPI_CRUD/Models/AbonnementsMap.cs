using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IDV_NET5.Models;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
namespace TodoAPI_CRUD.Models
{
    public class AbonnementsMap
    {
        public AbonnementsMap(EntityTypeBuilder<Abonnements> entityBuillder)
        {
            entityBuillder.HasKey(t => t.ID);
            entityBuillder.Property(t => t.PKAbonnement).IsRequired();
            entityBuillder.Property(t => t.Abonnement).IsRequired();
            entityBuillder.Property(t => t.PkAbonne).IsRequired();
            entityBuillder.Property(t => t.DateDebut).IsRequired();
            entityBuillder.Property(t => t.DateFin).IsRequired();
            entityBuillder.Property(t => t.Prix_Abonnement).IsRequired();
        }
    }
}