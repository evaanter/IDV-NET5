using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

namespace IDV_NET5.Models
{
    public class Abonnements
    {
        public long PK { get; set; }
        public string Abonnement { get; set; }
        public long PkAbonne { get; set; }
        public int PkCategorieAbonnement { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
    }
}


