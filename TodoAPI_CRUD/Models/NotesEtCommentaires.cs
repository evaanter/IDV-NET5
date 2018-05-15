using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDV_NET5.Models
{
    public class NotesEtCommentaires
    {
        /// <summary>
        /// The id of the NotesEtCommentaire
        /// </summary>
        public long NotesEtCommentairesID { get; set; }
        /// <summary>
        /// The Commentaire of the NotesEtCommentaire
        /// </summary>
        public string Commentaire { get; set; }
        /// <summary>
        /// The note of the NotesEtCommentaire
        /// </summary>
        public int Note { get; set; }
        /// <summary>
        /// The Date creation of the NotesEtCommentaire
        /// </summary>
        public DateTime DateCreation { get; set; }
        /// <summary>
        /// The id user of the NotesEtCommentaire
        /// </summary>
        public long FichierCentralID { get; set; }
        /// <summary>
        /// The id article of the NotesEtCommentaire
        /// </summary>
        public long ArticleID { get; set; }
        /// <summary>
        /// The user of the NotesEtCommentaire
        /// </summary>
        public FichierCentral FichierCentral { get; set; }
        /// <summary>
        /// The Article of the NotesEtCommentaire
        /// </summary>
        public Articles Articles { get; set; }

    }
}
