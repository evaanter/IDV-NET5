using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;

[Table("Abonnements")]

public class Abonnements
{
    [Key]
    /// <summary>
    /// The Id Abonnement  
    /// </summary>

    public long AbonnementsID { get; set; }
    /// <summary>
    /// The Abonnement Name 
    /// </summary>

    public string Abonnement { get; set; }
    /// <summary>
    /// The Date when the Abonnement was start
    /// </summary>

    public DateTime DateDebut { get; set; }
    /// <summary>
    /// The Date when the Abonnement was end
    /// </summary>

    public DateTime DateFin { get; set; }
    /// <summary>
    /// The price of the Abonnement
    /// </summary>

    public long Prix_Abonnement { get; set; }
    /// <summary>
    /// The id user to the Abonnement
    /// </summary>

    public long pkAbonne { get; set; }
    /// <summary>
    /// The user have this abonnement
    /// </summary>

    public FichierCentral FichierCentral { get; set; }
}



