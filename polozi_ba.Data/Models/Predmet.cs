using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace polozi_ba.Data.Models
{
    public class Predmet
    {
        public int Id { get; set; }

        [Required]
        public string Naziv { get; set; }

        public List<KorisnikPredmet> KorisnikPredmeti { get; set; }

    }
}
