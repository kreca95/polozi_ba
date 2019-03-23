using polozi_ba.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace polozi_ba.Models.Panel
{
    public class KorisniciModel
    {
        public string Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Mail { get; set; }
        public IList<Korisnik> Uloga { get; set; }
    }
}
    