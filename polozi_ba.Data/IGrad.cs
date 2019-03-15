using polozi_ba.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace polozi_ba.Data
{
    public interface IGrad
    {
        Task Dodaj(Grad grad);
        Task Izbrisi(int id);
        void Azuriraj(Grad grad);
        Task NadjiGrad(int id);
        IEnumerable<Grad> SviGradovi();
    }
}
