using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PoliziaDiStato
{
    public class Verbale
    {
        public int IdVerbale { get; set; }
        public DateTime DataViolazione { get; set; }
        public string IndirizzoViolazione { get; set; }
        public string NominativoAgente { get; set; }
        public DateTime DataTrascrizione { get; set; }
        public decimal Importo { get; set; }
        public int Punti { get; set; }
        public int IdViolazione { get; set; }
        public int IdTrasgressore { get; set; }

    }
}