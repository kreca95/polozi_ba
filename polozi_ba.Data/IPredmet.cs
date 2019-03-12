using polozi_ba.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace polozi_ba.Data
{
    public interface IPredmet
    {
        Task Dodaj(Predmet predmet);
        Task Izbrisi(int id);
        void Azuriraj(Predmet predmet);

        Task<Predmet> NadjiPredmet(int id);
        IEnumerable<Predmet> SviPredmeti();

    }
}
