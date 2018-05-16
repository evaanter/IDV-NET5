
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using System.Configuration;



namespace IDV_NET5.Models
{
    public class Lecteur : FichierCentral
    {
        //string connectionString = ConfigurationManager.ConnectionStrings["DESKTOP-HFMPRSB"].ConnectionString;
        //    public void AddLecteur(FichierCentral lecteur)
        //{
        //    using (SqlConnection con = new SqlConnection(connectionString))
        //    {
        //        SqlCommand cmd = new SqlCommand("spAddLecteur", con);
        //        cmd.CommandType = CommandType.StoredProcedure;
        //        cmd.Parameters.AddWithValue("@Nom", lecteur.Nom);
        //        cmd.Parameters.AddWithValue("@Prenom", lecteur.Prenom);
        //        cmd.Parameters.AddWithValue("@Login", lecteur.Login);
        //        cmd.Parameters.AddWithValue("@Email", lecteur.Email);
        //        con.Open();
        //        cmd.ExecuteNonQuery();
        //        con.Close();

        //    }
        //}
    }
}
