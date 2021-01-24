using Microsoft.EntityFrameworkCore;
using SwapiRater.DAL.ModeConfig;
using SwapiRater.DAL.Models;

namespace SwapiRater.DAL
{
    public class SwapiContext : DbContext
    {
        private readonly string _connectionString;

        public SwapiContext()
        {

        }

        public SwapiContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        public SwapiContext(DbContextOptions<SwapiContext> options) : base(options)
        {

        }

        public DbSet<Movie> Movies { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            if (!builder.IsConfigured)
            {
                builder.UseSqlServer(_connectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            mb.HasDefaultSchema("dbo");
            mb.ApplyConfiguration(new MovieConfig());

            base.OnModelCreating(mb);
        }




    }
}
