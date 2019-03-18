using System;
using System.Collections.Generic;
using System.Text;

namespace polozi_ba.Data.Models
{
    public class KorisnikPredmet
    {
        public string KorisnikId { get; set; }
        public virtual Korisnik Korisnik { get; set; }

        public int PredmetId { get; set; }
        public virtual Predmet Predmet { get; set; }
    }
}
