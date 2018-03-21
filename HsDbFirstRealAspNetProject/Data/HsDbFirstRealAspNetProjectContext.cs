using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Hearthstone;
using HsDbFirstRealAspNetProject.Models.DbModel;

namespace HsDbFirstRealAspNetProject.Data
{
    public class HsDbFirstRealAspNetProjectContext : DbContext
    {
        public HsDbFirstRealAspNetProjectContext(DbContextOptions<HsDbFirstRealAspNetProjectContext> options)
            : base(options)
        {
        }

        public DbSet<CardInfo> CardInfo { get; set; }
        public DbSet<MinionsVsMechanic> MinionsVsMechanic { get; set; }
        public DbSet<Hero> Hero { get; set; }
        public DbSet<Minion> Minion { get; set; }
        public DbSet<Spell> Spell { get; set; }
        public DbSet<AdditionCardInfo> AdditionCardInfo { get; set; }
        public DbSet<Deck> Deck { get; set; }
        public DbSet<DeckVsCards> DeckVsCard { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CardInfo>().ToTable("CardInfo");
            modelBuilder.Entity<AdditionCardInfo>().ToTable("additionalCardInfo");
            modelBuilder.Entity<Hero>().ToTable("Hero");
            modelBuilder.Entity<Minion>().ToTable("Minion");
            modelBuilder.Entity<Spell>().ToTable("Spell");
            modelBuilder.Entity<Mechanic>().ToTable("Mechanic");
            modelBuilder.Entity<MinionsVsMechanic>().ToTable("MinionsVsMechanics");
            modelBuilder.Entity<Deck>().ToTable("Deck");
            modelBuilder.Entity<DeckVsCards>().ToTable("DeckVsCards");
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=(LocalDb)\MSSQLLocalDB;Initial Catalog=HsDbFirstRealAspNetProjectContext;Integrated Security=True");
        }
    }
}
