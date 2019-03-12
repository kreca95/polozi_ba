using polozi_ba.Data;
using polozi_ba.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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

        public async Task Dodaj(Data.Models.Predmet predmet)
        {
            await _context.Predmeti.AddAsync(predmet);
            await _context.SaveChangesAsync();
        }

        public async Task Izbrisi(int id)
        {
            var predmet = await _context.Predmeti.FirstOrDefaultAsync(p => p.Id == id);
            _context.Remove(predmet);
        }

        public async Task<Data.Models.Predmet> NadjiPredmet(int id)
        {
            var predmet = await _context.Predmeti.FirstOrDefaultAsync(p => p.Id == id);
            return predmet;
        }

        public IEnumerable<Data.Models.Predmet> SviPredmeti()
        {
            return _context.Predmeti;
        }
    }
}
