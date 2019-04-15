using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace polozi_ba.Models.Naslovna
{
    public class PretragaModel
    {
        public string KorisnikId { get; set; }
        public int GradId { get; set; }
        public int PredmetId { get; set; }
        public string Email { get; set; }
        public string NazivGrada { get; set; }
        public string NazivPredmeta { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

    }
}
