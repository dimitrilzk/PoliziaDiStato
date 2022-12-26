using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web;
using System.Web.Mvc;

namespace PoliziaDiStato.Controllers
{
    public class VerbaliController : Controller
    {

        // GET: Verbali
        public ActionResult Create()
        {
            List<SelectListItem> ListaTrasgressori = new List<SelectListItem>();
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["PoliziaMunicipale"].ToString();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT IdTrasgressore, Cognome, Nome FROM Anagrafica";
                cmd.Connection= con;
                SqlDataReader reader = cmd.ExecuteReader();
                if(reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string nome = reader["Nome"].ToString() ;
                        string cognome = reader["Cognome"].ToString();
                        SelectListItem item = new SelectListItem();
                        item.Text = $"{nome} {cognome}";
                        item.Value = reader["IdTrasgressore"].ToString();
                        ListaTrasgressori.Add(item);
                    }
                }
                con.Close();
            }
            catch
            {
                con.Close();
            }
            ViewBag.ListaT = ListaTrasgressori;

            List<SelectListItem> ListaViolazioni = new List<SelectListItem>();
            SqlConnection con2 = new SqlConnection();
            try
            {
                con2.ConnectionString = ConfigurationManager.ConnectionStrings["PoliziaMunicipale"].ToString();
                con2.Open();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.CommandText = "SELECT * FROM TipoViolazione";
                cmd2.Connection= con2;
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if(reader2.HasRows)
                {
                    while (reader2.Read())
                    {
                        SelectListItem item = new SelectListItem();
                        item.Text = reader2["Descrizione"].ToString() ;
                        item.Value = reader2["IdViolazione"].ToString();
                        ListaViolazioni.Add(item);
                    }
                }
                con2.Close();
            }
            catch
            {
                con2.Close();
            }
            ViewBag.ListaV = ListaViolazioni;

            return View();
        }
    }
}