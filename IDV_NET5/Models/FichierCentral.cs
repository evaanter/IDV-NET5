using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;


public class FichierCentral
{
    public long PK { get; set; }

    public Guid UserId { get; set; }

    public int PkProfil { get; set; }

    public string Nom {get; set;}

    public string Prenom
    {
        get;
        set;
    }

    public string Login
    {
        get;
        set;
    }

    public string Email
    {
        get;
        set;
    }

    public DateTime DateCreation
    {
        get;
        set;
    }

    public string Abonnement
    {
        get;
        set;
    }

    public int PkCategorieAbonnement
    {
        get;
        set;
    }

    public int PkAbonnemnt
    {
        get;
        set;
    }



}

