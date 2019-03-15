using polozi_ba.Data;
using polozi_ba.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace polozi_ba.Service
{
    public class PredmetService : IPredmet
    {
        private readonly PoloziBaContext _context;

        public PredmetService(PoloziBaContext context)
        {
            _context = context;
        }
        public void Azuriraj(Data.Models.Predmet predmet)
        {
            _context.Predmeti.Update(predmet);
            _context.SaveChanges();
        }

        public void Dodaj(Data.Models.Predmet predmet)
        {
             _context.Predmeti.Add(predmet);
             _context.SaveChanges();
        }

        public void Izbrisi(int id)
        {
            var predmet = _context.Predmeti.FirstOrDefault(p=> p.Id==id);
            _context.Remove(predmet);
            _context.SaveChanges();
        }

        public polozi_ba.Data.Models.Predmet NadjiPredmet(int id)
        {
            var predmet = _context.Predmeti.Where(p => p.Id == id).FirstOrDefault();

            return predmet;
        }

        public IEnumerable<Data.Models.Predmet> SviPredmeti()
        {
            return _context.Predmeti;
        }
    }
}
