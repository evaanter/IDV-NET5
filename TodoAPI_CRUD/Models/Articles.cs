using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.VisualBasic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using TodoAPI_CRUD.Models;

[Table("Articles")]


public class Articles
{

    /// <summary>
    /// The Id  of the Article
    /// </summary>
    [Key]
    public long ArticlesID { get; set; }
    /// <summary>
    /// The Id user of the Article
    /// </summary>

    public long FichierCentralID { get; set; }
    /// <summary>
    /// The title  of the Article
    /// </summary>

    public string TitreArticle { get; set; }
    /// <summary>
    /// The sentence of the Article
    /// </summary>

    public string PhraseAcroche { get; set; }
    /// <summary>
    /// The content  of the Article
    /// </summary>

    public string TextArticle { get; set; }
    /// <summary>
    /// The date create of the Article
    /// </summary>

    public DateTime DateCreation { get; set; }
    /// <summary>
    /// The login user of the Article
    /// </summary>

    public string LoginCreation { get; set; }
    /// <summary>
    /// The date update of the Article
    /// </summary>

    public DateTime DateModification { get; set; }
    /// <summary>
    /// The login update of the Article
    /// </summary>

    public string LoginModification { get; set; }
    /// <summary>
    /// The date delete of the Article
    /// </summary>

    public DateTime DateDelete { get; set; }
    /// <summary>
    /// The login user delete of the Article
    /// </summary>

    public string LoginDelete { get; set; }
    /// <summary>
    /// The user of the Article
    /// </summary>

    public FichierCentral FichierCentral { get; set; }
    /// <summary>
    /// The categorie media of the Article
    /// </summary>

    public List<CategoriesMedia> CategoriesMedia { get; set; }
    /// <summary>
    /// The abonnement user  of the Article
    /// </summary>

    public List<Abonnements> Abonnements { get; set; }


}

