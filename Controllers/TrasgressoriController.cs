using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoliziaDiStato.Controllers
{
    public class TrasgressoriController : Controller
    {
        // GET: Trasgressori
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Trasgressore t)
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["PoliziaMunicipale"].ToString();
                con.Open();

                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@Cognome", t.Cognome);
                cmd.Parameters.AddWithValue("@Nome", t.Nome);
                cmd.Parameters.AddWithValue("@Indirizzo", t.Indirizzo);
                cmd.Parameters.AddWithValue("@Citta", t.Citta);
                cmd.Parameters.AddWithValue("@Cap", t.Cap);
                cmd.Parameters.AddWithValue("@Cf", t.CodiceFiscale);

                cmd.CommandText = "INSERT INTO Anagrafica VALUES (@Cognome, @Nome, @Indirizzo, @Citta, @Cap, @Cf)";
                cmd.Connection= con;
                cmd.ExecuteNonQuery();
                con.Close();
            }
            catch
            {
                con.Close();
            }
            return View();
        }
    }
}