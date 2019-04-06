using polozi_ba.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace polozi_ba.Data
{
    public interface IGrad
    {
        void Dodaj(Grad grad);
        void Izbrisi(Grad grad);
        void Azuriraj(Grad grad);
        Grad NadjiGrad(int id);
        IEnumerable<Grad> SviGradovi();
        IQueryable<Grad> KorisnikoviGradovi(Korisnik korisnik);

        void DodajGradKorisniku(int gradId,string korisnikId);

        void IzbrisiGradKorisniku(int gradId, string userId);
    }
}
