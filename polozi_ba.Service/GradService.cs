using Microsoft.EntityFrameworkCore;
using polozi_ba.Data;
using polozi_ba.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace polozi_ba.Service
{
    public class GradService : IGrad
    {

        private readonly PoloziBaContext _context;

        public GradService(PoloziBaContext context)
        {
            _context = context;
        }

        public void Azuriraj(Grad grad)
        {
            _context.Gradovi.Update(grad);
            _context.SaveChanges();
        }

        public void Dodaj(Grad grad)
        {
            _context.Gradovi.Add(grad);
            _context.SaveChanges();
        }

        public void Izbrisi(int id)
        {
           var grad= _context.Gradovi.FirstOrDefault(x=> x.Id==id);
            _context.Remove(grad);
        }

        public Grad NadjiGrad(int id)
        {
            return _context.Gradovi.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<Grad> SviGradovi()
        {
            return _context.Gradovi;
        }
    }
}
