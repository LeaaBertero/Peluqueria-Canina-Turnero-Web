using Microsoft.EntityFrameworkCore;
using PeluCaninaWeb.BD.Data.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluCaninaWeb.BD.Data
{
    public class Context : DbContext
    {
        #region constructor BD
        public Context(DbContextOptions options) : base(options)
        {
        }
        #endregion

        #region entidades
            
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<Promocion> Promocion { get; set; }
        public DbSet<Turno> Turno { get; set; }
        public DbSet<Mascota> Mascota { get; set; }
        public DbSet<TurnoServicio> TurnoServicio { get; set; }
        public DbSet<Usuario> Usuario { get; set; }

        #endregion


    }
}
