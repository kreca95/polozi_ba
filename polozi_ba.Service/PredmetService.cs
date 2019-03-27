using polozi_ba.Data;
using polozi_ba.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Query;

namespace polozi_ba.Service
{
    public class PredmetService : IPredmet
    {
        private readonly PoloziBaContext _context;
        private readonly UserManager<Korisnik> _userManager;

        public PredmetService(PoloziBaContext context, UserManager<Korisnik> userManager)
        {
            _context = context;
            _userManager = userManager;
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

        public void DodajPredmetKorisniku(int idPredmet, string korisnikId)
        {
            var korisnikpredmet = new KorisnikPredmet()
            {
                KorisnikId = korisnikId,
                PredmetId = idPredmet
            };
            _context.KorisnikPredmet.Add(korisnikpredmet);
            _context.SaveChanges();
        }

        public void Izbrisi(int id)
        {
            var predmet = _context.Predmeti.FirstOrDefault(p => p.Id == id);
            _context.Remove(predmet);
            _context.SaveChanges();
        }

        public void IzbrisiPredmetKorisniku(int idPredmet,string korisnikId)
        {
            var korisnikPredmet = _context.KorisnikPredmet.Where(x => x.KorisnikId == korisnikId && x.PredmetId == idPredmet).SingleOrDefault();

            if (korisnikPredmet!=null)
            {
                _context.KorisnikPredmet.Remove(korisnikPredmet);
                _context.SaveChanges();
            }
        }

        public IQueryable<polozi_ba.Data.Models.Predmet> KorisnikoviPredmeti(Korisnik korisnik)
        {
            var predmeti = _context.Predmeti.FromSql($"select p.Naziv,p.Id from AspNetUsers u,KorisnikPredmet kp,Predmeti p where u.Id = {korisnik.Id}  and p.Id = kp.PredmetId");
            return predmeti;
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
