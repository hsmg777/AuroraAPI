using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using AuroraAPI.Models;

namespace AuroraAPI.Data
{
    public class AuroraAPIContext : DbContext
    {
        public AuroraAPIContext(DbContextOptions<AuroraAPIContext> options)
            : base(options)
        {
        }

        public DbSet<Fiestas> Fiestas { get; set; } = default!;
        public DbSet<Reservas>? Reservas { get; set; }
        public DbSet<galeria>? galeria { get; set; }
        public DbSet<about>? aboutUs { get; set; }
        public DbSet<contact>? contact { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<about>().ToTable("about");
            modelBuilder.Entity<politicas>().ToTable("politicas");
        }
        public DbSet<politicas>? politicas { get; set; }
    
    }
}
