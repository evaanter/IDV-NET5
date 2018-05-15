using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI_CRUD.Models
{
    public class Images
    {   /// <summary>
        /// The Id of the Image
        /// </summary>

        public long ImagesID { get; set; }
        /// <summary>
        /// The name  of the Image
        /// </summary>

        public string NomImage { get; set; }
        /// <summary>
        /// The URL chemin  of the Image
        /// </summary>

        public string URLImage { get; set; }
        /// <summary>
        /// The Id categorie of the Image
        /// </summary>

        public long CategorieID { get; set; }
        /// <summary>
        /// The Id article of the Image
        /// </summary>

        public long ArticleID { get; set; }
        /// <summary>
        /// The categorie media of the Image
        /// </summary>

        public CategoriesMedia CategoriesMedia { get; set; }
        /// <summary>
        /// The article of the Image
        /// </summary>

        public Articles Articles { get; set; }
    }
}
