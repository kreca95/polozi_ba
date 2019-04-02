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

        public void DodajGradKorisniku(int gradId, string korisnikId)
        {
            _context.KorisnikGrad.Add(new KorisnikGrad { GradId = gradId, KorisnikId = korisnikId });
            _context.SaveChanges();
        }

        public void Izbrisi(int id)
        {
           var grad= _context.Gradovi.FirstOrDefault(x=> x.Id==id);
            _context.Remove(grad);
        }

        public IQueryable<Grad> KorisnikoviGradovi(Korisnik korisnik)
        {
            var gradovi = _context.Gradovi.FromSql($"select g.Naziv,g.Id from AspNetUsers u,KorisnikGrad kg,Gradovi g where u.Id = '70fd5924-cf3b-484b-b5f3-b1c75ea1116c'  and g.Id = kg.GradId");

            return gradovi;
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
