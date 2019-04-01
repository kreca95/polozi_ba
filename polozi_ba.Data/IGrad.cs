using polozi_ba.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace polozi_ba.Data
{
    public interface IGrad
    {
        void Dodaj(Grad grad);
        void Izbrisi(int id);
        void Azuriraj(Grad grad);
        Grad NadjiGrad(int id);
        IEnumerable<Grad> SviGradovi();
    }
}
