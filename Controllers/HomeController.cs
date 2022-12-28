using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;

namespace PoliziaDiStato.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult PartialViewVerbali()
        {
            SqlConnection con = new SqlConnection();
            List<Verbale> ListaVerbaliPartial = new List<Verbale>();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["PoliziaMunicipale"].ToString();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "Select Count(*) as Verbali, Cognome, Nome from Anagrafica inner join Verbale on " +
                    " VERBALE.IdTrasgressore = ANAGRAFICA.IdTrasgressore group by Cognome, Nome order by Verbali Desc";
                cmd.Connection = con;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Verbale v = new Verbale();
                        v.Nome = reader["Nome"].ToString();
                        v.Cognome = reader["Cognome"].ToString();
                        v.Verbali = Convert.ToInt32(reader["Verbali"]);
                        ListaVerbaliPartial.Add(v);
                    }
                }
                con.Close();
            }
            catch
            {
                con.Close();
            }
            return PartialView("_PartialViewVerbali",ListaVerbaliPartial);
        }
        public ActionResult PartialViewPunti()
        {
            SqlConnection con = new SqlConnection();
            List<Verbale> ListaPuntiPartial = new List<Verbale>();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["PoliziaMunicipale"].ToString();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select sum(DecurtamentoPunti) as TotPunti, Cognome, Nome from Verbale inner join Anagrafica on " +
                                  "Verbale.IdTrasgressore = Anagrafica.IdTrasgressore group by Cognome, Nome order by TotPunti Desc";
                cmd.Connection = con;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Verbale v = new Verbale();
                        v.Nome = reader["Nome"].ToString();
                        v.Cognome = reader["Cognome"].ToString();
                        v.Punti = Convert.ToInt32(reader["TotPunti"]);
                        ListaPuntiPartial.Add(v);
                    }
                }
                con.Close();
            }
            catch
            {
                con.Close();
            }
            return PartialView("_PartialViewPunti", ListaPuntiPartial);
        }
        public ActionResult PartialView10Punti()
        {
            SqlConnection con = new SqlConnection();
            List<Verbale> Lista10PuntiPartial = new List<Verbale>();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["PoliziaMunicipale"].ToString();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select Importo, Cognome, Nome, DataViolazione, DecurtamentoPunti from Verbale inner join Anagrafica on " +
                                  "Verbale.IdTrasgressore = Anagrafica.IdTrasgressore where DecurtamentoPunti > 10";
                cmd.Connection = con;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Verbale v = new Verbale();
                        v.Importo = Convert.ToInt32(reader["Importo"]);
                        v.Nome = reader["Nome"].ToString();
                        v.Cognome = reader["Cognome"].ToString();
                        v.DataViolazione = Convert.ToDateTime(reader["DataViolazione"]);
                        v.Punti = Convert.ToInt32(reader["DecurtamentoPunti"]);
                        Lista10PuntiPartial.Add(v);
                    }
                }
                con.Close();
            }
            catch
            {
                con.Close();
            }
            return PartialView("_PartialView10Punti", Lista10PuntiPartial);
        }
        public ActionResult PartialView400Euro()
        {
            SqlConnection con = new SqlConnection();
            List<Verbale> Lista400EuroPartial = new List<Verbale>();
            try
            {
                con.ConnectionString = ConfigurationManager.ConnectionStrings["PoliziaMunicipale"].ToString();
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "select Importo, Cognome, Nome from Verbale inner join Anagrafica on " +
                                  "Verbale.IdTrasgressore = Anagrafica.IdTrasgressore where Importo > 400 order by Importo Desc";
                cmd.Connection = con;
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        Verbale v = new Verbale();
                        v.Importo = Convert.ToInt32(reader["Importo"]);
                        v.Nome = reader["Nome"].ToString();
                        v.Cognome = reader["Cognome"].ToString();
                        Lista400EuroPartial.Add(v);
                    }
                }
                con.Close();
            }
            catch
            {
                con.Close();
            }
            return PartialView("_PartialView400Euro", Lista400EuroPartial);
        }
    }
}