using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PoliziaDiStato
{
    public class Verbale
    {
        public int IdVerbale { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode =true)]
        public DateTime DataViolazione { get; set; }
        public string IndirizzoViolazione { get; set; }
        public string NominativoAgente { get; set; }
        public DateTime DataTrascrizione { get; set; }
        [DataType(DataType.Currency)]
        public decimal Importo { get; set; }
        public int Punti { get; set; }
        public int IdViolazione { get; set; }
        public int IdTrasgressore { get; set; }
        public string Nome { get; set; }
        public string Cognome { get; set; }
        public int Verbali { get; set; }
    }
}