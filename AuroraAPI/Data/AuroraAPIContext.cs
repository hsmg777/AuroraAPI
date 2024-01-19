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
        public AuroraAPIContext (DbContextOptions<AuroraAPIContext> options)
            : base(options)
        {
        }

        public DbSet<AuroraAPI.Models.Fiestas> Fiestas { get; set; } = default!;

        public DbSet<AuroraAPI.Models.Reservas>? Reservas { get; set; }
    }
}
