using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoP1_final.Models;

namespace ProyectoP1_final.Data
{
    public class ProyectoP1_finalContext : DbContext
    {
        public ProyectoP1_finalContext (DbContextOptions<ProyectoP1_finalContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoP1_final.Models.Habitacion> Habitacion { get; set; } = default!;

        public DbSet<ProyectoP1_final.Models.Huesped>? Huesped { get; set; }

        public DbSet<ProyectoP1_final.Models.Reserva>? Reserva { get; set; }
    }
}
