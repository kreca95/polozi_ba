using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using polozi_ba.Data;
using polozi_ba.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace polozi_ba.Service
{
    public class PoloziBaService : IPoloziBa
    {
        private readonly PoloziBaContext _context;

        public PoloziBaService(PoloziBaContext context)
        {
            _context = context;
        }

        public IQueryable<PretragaModel> NadjiKorisnikePrekoPredmetaIGrada(int predmetId, int gradId)
        {
            //var model = _context.Database.ExecuteSqlCommand("select AspNetUsers.Email,KorisnikGrad.GradId,KorisnikPredmet.PredmetId,AspNetUsers.Id from AspNetUsers full outer join KorisnikGrad on AspNetUsers.Id = KorisnikGrad.KorisnikId full outer join KorisnikPredmet on AspNetUsers.Id = KorisnikPredmet.KorisnikId full outer join Predmeti on KorisnikPredmet.PredmetId = Predmeti.Id");

            var pretragaModel = (from us in _context.Korisnici
                                 join kg in _context.KorisnikGrad
                                 on us.Id equals kg.KorisnikId
                                 where kg.GradId == gradId
                                 join kp in _context.KorisnikPredmet
                                 on us.Id equals kp.KorisnikId
                                 where kp.PredmetId == predmetId

                                 select new PretragaModel
                                 {
                                     KorisnikId = us.Id,
                                     PredmetId = kp.PredmetId,
                                     GradId = kg.GradId,
                                     Email=us.Email,
                                     NazivGrada=kg.Grad.Naziv,
                                     NazivPredmeta=kp.Predmet.Naziv
                                 }
                               );
            return pretragaModel;
        }
    }
}