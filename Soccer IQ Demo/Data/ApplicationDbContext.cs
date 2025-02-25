using Microsoft.EntityFrameworkCore;
using Soccer_IQ_Demo.Models;

namespace Soccer_IQ_Demo.Data
{
    public class ApplicationDbContext:DbContext
    {

        public DbSet<Player> Players { get; set; }
        public DbSet<PlayerStat> PlayerStats { get; set; }
        public DbSet<Club> Clubs { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var Builder = new ConfigurationBuilder().AddJsonFile("appsettings.json", true, true).Build();
            var connection = Builder.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connection);

        }



    }
}
