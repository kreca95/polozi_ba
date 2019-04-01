using polozi_ba.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace polozi_ba.Data.Models
{
    public class Grad
    {
        public int Id { get; set; }
        public string Naziv { get; set; }

        public virtual List<KorisnikGrad> KorisnikGrad { get; set; }
    }
}
