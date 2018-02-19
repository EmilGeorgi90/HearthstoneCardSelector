using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hearthstone;

namespace HsDbFirstRealAspNetProject.Models
{
    public class HsDbFirstRealAspNetProjectContext : DbContext
    {
        public HsDbFirstRealAspNetProjectContext (DbContextOptions<HsDbFirstRealAspNetProjectContext> options)
            : base(options)
        {
        }

        public DbSet<Hearthstone.Hs> Hs { get; set; }
    }
}
