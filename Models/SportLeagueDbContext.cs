using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace SportLeague.Models
{
    public class SportsLeaguesDbContext : DbContext
    {
        public SportsLeaguesDbContext()
        {

        }

        public virtual DbSet<Sport> Sports { get; set; }
        public virtual DbSet<League> Leauges { get; set; }
        public virtual DbSet<Division> Divisions { get; set; }
        public virtual DbSet<Team> Teams { get; set; }
        public virtual DbSet<Player> Players { get; set; }
        public virtual DbSet<Game> Games { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseMySql(@"Server=localhost;Port=8889;database=SportLeague;uid=root;pwd=root;");
        }

        public SportsLeaguesDbContext(DbContextOptions<SportsLeaguesDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
