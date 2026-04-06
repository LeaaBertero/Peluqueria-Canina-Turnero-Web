using PeluCaninaWeb.BD.Data;
using PeluCaninaWeb.BD.Data.Entity;

namespace PeluCaninaWeb.Server.Repositorio
{
    public class TurnoServicioRepositorio : Repositorio<Turno>, ITurnoServicioRepositorio
    {
        public TurnoServicioRepositorio(Context context) : base(context)
        {
        }
    }
}
