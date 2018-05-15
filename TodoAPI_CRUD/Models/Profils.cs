using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI_CRUD.Models
{
    public class Profils
    {
        /// <summary>
        /// The Id profil of the Profil
        /// </summary>
        public long ProfilsID { get; set; }
        /// <summary>
        /// The code  of the Profil
        /// </summary>
        public int CodeProfil { get; set; }
        /// <summary>
        /// The name of the Profil
        /// </summary>
        public string ProfilName { get; set; }
    }
}
