using polozi_ba.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace polozi_ba.Data
{
    public interface IPredmet
    {
        void Dodaj(Predmet predmet);
        void Izbrisi(int id);
        void Azuriraj(Predmet predmet);

        Predmet NadjiPredmet(int id);

        IEnumerable<Predmet> SviPredmeti();

    }
}
