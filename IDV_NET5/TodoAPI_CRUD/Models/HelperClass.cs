using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoAPI_CRUD.Models
{
   
    public class HelperClass
    {
        [Serializable]
        public class User
        {
            public int PkProfil { get; set; }
            public string Nom { get; set; }
            public string Prenom { get; set; }
            public string Login { get; set; }
            public string Email { get; set; }
            public string DateCreation { get; set; }

        }
    }
}
