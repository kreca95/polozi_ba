using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace polozi_ba.Data.Models
{
    public class Korisnik : IdentityUser
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }

        public int BrojGradova { get; set; }


        public List<KorisnikPredmet> KorisnikPredmeti { get; set; }
        public string RoleId { get; set; }

        public virtual IdentityRole Role { get; set; }

        public virtual List<KorisnikGrad> KorisnikGrad { get; set; }

        public string SlikaUrl { get; set; }
    }
}
