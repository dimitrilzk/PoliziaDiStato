using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PoliziaDiStato.Controllers
{
    public class VerbaliController : Controller
    {
        // GET: Verbali
        public ActionResult Create()
        {
            return View();
        }
    }
}