using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoliziaDiStato
{
    public class Trasgressore
    {
        public int IdTrasgressore { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public string Indirizzo { get; set; }
        public string Citta { get; set; }
        public int Cap { get; set; }
        public string CodiceFiscale { get; set; }

    }
}