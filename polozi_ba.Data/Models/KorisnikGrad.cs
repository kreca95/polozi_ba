using System;
using System.Collections.Generic;
using System.Text;

namespace polozi_ba.Data.Models
{
    public class KorisnikGrad
    {
        public string KorisnikId { get; set; }
        public Korisnik Korisnik { get; set; }

        public int GradId { get; set; }
        public Grad Grad { get; set; }
    }
}
