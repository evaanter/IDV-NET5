using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TodoAPI_CRUD.Models;

[Table("FichierCentral")]

public class FichierCentral
{
    /// <summary>
    /// The ID user 
    /// </summary>
    public long FichierCentralID { get; set; }
    /// <summary>
    /// The Identifian unquie user 
    /// </summary>
    public Guid UserId { get; set; }
    /// <summary>
    /// The Name user 
    /// </summary>
    public string Nom { get; set; }
    /// <summary>
    /// The Firstname user 
    /// </summary>
    public string Prenom { get; set; }
    /// <summary>
    /// The Login  user 
    /// </summary>
    public string Login { get; set; }
    /// <summary>
    /// The password  user 
    /// </summary>
    public string Password { get; set; }
    /// <summary>
    /// The Email user 
    /// </summary>
    public string Email { get; set; }
    /// <summary>
    /// The DateCreation of this  user 
    /// </summary>
    public DateTime DateCreation { get; set; }
    /// <summary>
    /// The id profil for this user 
    /// </summary>
    public long ProfilsID { get; set; }
    /// <summary>
    /// The profil of the user
    /// </summary>

    public Profils profils { get; set; }
    /// <summary>
    /// The Id Abonnement for user
    /// </summary>

    public long AbonnementsID { get; set; }
    /// <summary>
    /// The Abonnements for user
    /// </summary>

    public Abonnements Abonnements { get; set; }

}

