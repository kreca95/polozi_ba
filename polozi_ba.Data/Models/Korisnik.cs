using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;

namespace polozi_ba.Data.Models
{
    public class Korisnik : IdentityUser
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }


        public List<KorisnikPredmet> KorisnikPredmeti { get; set; }

    }
}
