using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI_CRUD.Models
{
    public class Videos
    {

        /// <summary>
        /// The Id of the Video
        /// </summary>

        public long VideosID { get; set; }
        /// <summary>
        /// The URL chemin  of the Video
        /// </summary>

        public string URLVideo { get; set; }
        /// <summary>
        /// The id categorie media of the Video
        /// </summary>

        public long CategoriesMediaID { get; set; }
        /// <summary>
        /// The Id article of the Video
        /// </summary>

        public long ArticlesID { get; set; }
        /// <summary>
        /// The categorie of the Video
        /// </summary>

        public CategoriesMedia CategoriesMedia { get; set; }
        /// <summary>
        /// The article of the Video
        /// </summary>

        public Articles Articles { get; set; }

    }
}
