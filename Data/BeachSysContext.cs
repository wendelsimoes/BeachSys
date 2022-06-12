using BeachSys.Models;
using Microsoft.EntityFrameworkCore;

namespace BeachSys.Data
{
    public class BeachSysContext : DbContext
    {
        public BeachSysContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Armario> Armarios { get; set; }
        public DbSet<Compartimento> Compartimentos { get; set; }
        public DbSet<Admin> Admins { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Admin>().HasData(
                new Admin()
                {
                    ID = 1,
                    Nome = "admin",
                    CPF = "admin",
                    Email = "admin"
                }
            );
        }
    }
}