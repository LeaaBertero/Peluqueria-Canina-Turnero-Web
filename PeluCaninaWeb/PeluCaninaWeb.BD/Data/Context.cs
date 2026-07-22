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
        #region constructor del context
        public Context(DbContextOptions options) : base(options)
        {
        }
        #endregion


        #region entidades
        public DbSet<Mascota> Mascota { get; set; }
        public DbSet<Promocion> Promocion { get; set; }
        public DbSet<Servicio> Servicio { get; set; }
        public DbSet<Turno> Turno { get; set; }
        public DbSet<TurnoServicio> TurnoServicio { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        #endregion




        #region codigo que evita el borrado en cascada de las tablas relacionadas
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var cascadeFKs = modelBuilder.Model.G­etEntityTypes()
                                            .SelectMany(t => t.GetForeignKeys())
                                            .Where(fk => !fk.IsOwnership
                                                        && fk.DeleteBehavior == DeleteBehavior.Casca­de);
            foreach (var fk in cascadeFKs)
            {
                fk.DeleteBehavior = DeleteBehavior.Restr­ict;
            }

            base.OnModelCreating(modelBuilder);
           

        }
        #endregion
    }

}
