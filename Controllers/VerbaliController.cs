using Antlr.Runtime.Misc;
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
        private List<SelectListItem> GetTrasgressori()
        {
            List<SelectListItem> ListaTrasgressori = new List<SelectListItem>();
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["PoliziaMunicipale"].ToString();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT IdTrasgressore, Cognome, Nome FROM Anagrafica";
                cmd.Connection = con;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        string nome = reader["Nome"].ToString();
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
            return ListaTrasgressori;
        }
        private List<SelectListItem> GetViolazioni()
        {
            List<SelectListItem> ListaViolazioni = new List<SelectListItem>();
            SqlConnection con2 = new SqlConnection();
            try
            {
                con2.ConnectionString = ConfigurationManager.ConnectionStrings["PoliziaMunicipale"].ToString();
                con2.Open();
                SqlCommand cmd2 = new SqlCommand();
                cmd2.CommandText = "SELECT * FROM TipoViolazione";
                cmd2.Connection = con2;
                SqlDataReader reader2 = cmd2.ExecuteReader();
                if (reader2.HasRows)
                {
                    while (reader2.Read())
                    {
                        SelectListItem item = new SelectListItem();
                        item.Text = reader2["Descrizione"].ToString();
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
            return ListaViolazioni;
        }
        // GET: Verbali
        public ActionResult Create()
        {
            //List<SelectListItem> ListaTrasgressori = new List<SelectListItem>();
            //SqlConnection con = new SqlConnection();
            //try
            //{
            //    con.ConnectionString = ConfigurationManager.ConnectionStrings["PoliziaMunicipale"].ToString();
            //    con.Open();
            //    SqlCommand cmd = new SqlCommand();
            //    cmd.CommandText = "SELECT IdTrasgressore, Cognome, Nome FROM Anagrafica";
            //    cmd.Connection = con;
            //    SqlDataReader reader = cmd.ExecuteReader();
            //    if (reader.HasRows)
            //    {
            //        while (reader.Read())
            //        {
            //            string nome = reader["Nome"].ToString();
            //            string cognome = reader["Cognome"].ToString();
            //            SelectListItem item = new SelectListItem();
            //            item.Text = $"{nome} {cognome}";
            //            item.Value = reader["IdTrasgressore"].ToString();
            //            ListaTrasgressori.Add(item);
            //        }
            //    }
            //    con.Close();
            //}
            //catch
            //{
            //    con.Close();
            //}
            ViewBag.ListaT = GetTrasgressori();

            //List<SelectListItem> ListaViolazioni = new List<SelectListItem>();
            //SqlConnection con2 = new SqlConnection();
            //try
            //{
            //    con2.ConnectionString = ConfigurationManager.ConnectionStrings["PoliziaMunicipale"].ToString();
            //    con2.Open();
            //    SqlCommand cmd2 = new SqlCommand();
            //    cmd2.CommandText = "SELECT * FROM TipoViolazione";
            //    cmd2.Connection = con2;
            //    SqlDataReader reader2 = cmd2.ExecuteReader();
            //    if (reader2.HasRows)
            //    {
            //        while (reader2.Read())
            //        {
            //            SelectListItem item = new SelectListItem();
            //            item.Text = reader2["Descrizione"].ToString();
            //            item.Value = reader2["IdViolazione"].ToString();
            //            ListaViolazioni.Add(item);
            //        }
            //    }
            //    con2.Close();
            //}
            //catch
            //{
            //    con2.Close();
            //}
            ViewBag.ListaV = GetViolazioni();

            return View();
        }

        [HttpPost]
        public ActionResult Create(Verbale v, string ListaViolazioni, string ListaTrasgressori)
        {
            ViewBag.ListaV= GetViolazioni();
            ViewBag.ListaT= GetTrasgressori();
            SqlConnection con = new SqlConnection();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["PoliziaMunicipale"].ToString();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@DataViolazione", v.DataViolazione);
                cmd.Parameters.AddWithValue("@Indirizzo", v.IndirizzoViolazione);
                cmd.Parameters.AddWithValue("@NominativoAg", v.NominativoAgente);
                cmd.Parameters.AddWithValue("@DataTrascizione", v.DataViolazione);
                cmd.Parameters.AddWithValue("@Importo", v.Importo);
                cmd.Parameters.AddWithValue("@Punti", v.Punti);
                cmd.Parameters.AddWithValue("@Violazione", ListaViolazioni);
                cmd.Parameters.AddWithValue("@Trasgressore", ListaTrasgressori);
                cmd.CommandText = "INSERT INTO Verbale VALUES (@DataViolazione, @Indirizzo, @NominativoAg, @DataTrascizione," +
                                                         " @Importo, @Punti, @Violazione, @Trasgressore)";
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