using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

[Table("Abonnements")]

    public class Abonnements
    {
        public long ID { get; set; }
        public long PKAbonnement { get; set; }
        public new string Abonnement { get; set; }
        public long PkAbonne { get; set; }
        public DateTime DateDebut { get; set; }
        public DateTime DateFin { get; set; }
        public long Prix_Abonnement { get; set; }
    }



