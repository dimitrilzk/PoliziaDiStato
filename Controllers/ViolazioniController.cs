using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoliziaDiStato.Controllers
{
    public class ViolazioniController : Controller
    {
        // GET: Violazioni
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Violazione v) 
        {
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["PoliziaMunicipale"].ToString();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@Descrizione", v.Descrizione);

                cmd.CommandText = "INSERT INTO TipoViolazione VALUES (@Descrizione)";
                cmd.Connection= con;
                cmd.ExecuteNonQuery();
                con.Close();
            }catch
            {
                con.Close();
            }
            return View();
        }
    }
}