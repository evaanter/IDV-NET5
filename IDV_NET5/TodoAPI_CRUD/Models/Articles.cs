using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IDV_NET5.Models
{
    public class Articles
    {
        public long Pk
        {
            get;
            set;
        }

        public int PkCategorie
        {
            get;
            set;
        }

        public long PkRedacteur
        {
            get;
            set;
        }

        public string TitreArticle
        {
            get;
            set;
        }

        public string PhraseAcroche
        {
            get;
            set;
        }

        public string TextArticle
        {
            get;
            set;
        }

        public int PkCategorieMedia
        {
            get;
            set;
        }

        public string ImageUrl
        {
            get;
            set;
        }

        public string VideoUrl
        {
            get;
            set;
        }

        public DateTime DateCreation
        {
            get;
            set;
        }

        public string LoginCreation
        {
            get;
            set;
        }

        public DateTime DateModification
        {
            get;
            set;
        }

        public string LoginModification
        {
            get;
            set;
        }
    }
}
