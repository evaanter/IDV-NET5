using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDV_NET5.Models
{
    public class NotesEtCommentaires
    {
        public long PK
        {
            get;
            set;
        }

        public string Commentaire
        {
            get;
            set;
        }

        public int Note
        {
            get;
            set;
        }

        public DateTime DateCreation
        {
            get;
            set;
        }

        public long PkArticle
        {
            get;
            set;
        }

        public long PkCommentateur
        {
            get;
            set;
        }
    }
}
