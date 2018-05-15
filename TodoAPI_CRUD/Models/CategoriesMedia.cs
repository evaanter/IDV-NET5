using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI_CRUD.Models
{
    public class CategoriesMedia
    {
        /// <summary>
        /// The id  CategoriesMedia
        /// </summary>
        public long CategoriesMediaID { get; set; }
        /// <summary>
        /// The Type Categorie Medias of CategoriesMedia
        /// </summary>
        public string TypeCategorieMedia { get; set; }
        /// <summary>
        /// The List Video of  CategoriesMedia
        /// </summary>
        public List<Videos> ListVideo { get; set; }
        /// <summary>
        /// The List Image of CategoriesMedia
        /// </summary>
        public List<Images> ListImage { get; set; }
    }
}
