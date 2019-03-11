using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using polozi_ba.Data.Models;

namespace polozi_ba.Data
{
    public class PoloziBaContext : IdentityDbContext<Korisnik>
    {
        public PoloziBaContext(DbContextOptions<PoloziBaContext> options)
            : base(options)
        {

        }
    }
}
