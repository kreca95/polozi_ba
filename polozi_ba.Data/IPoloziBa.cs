using polozi_ba.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace polozi_ba.Data
{
    public interface IPoloziBa
    {
        IQueryable<PretragaModel> NadjiKorisnikePrekoPredmetaIGrada(int predmetId,int gradId);
    }
}