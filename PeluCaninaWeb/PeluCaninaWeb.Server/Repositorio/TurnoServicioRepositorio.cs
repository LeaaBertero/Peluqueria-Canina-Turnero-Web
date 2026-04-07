using PeluCaninaWeb.BD.Data;
using PeluCaninaWeb.BD.Data.Entity;

namespace PeluCaninaWeb.Server.Repositorio
{
    public class TurnoServicioRepositorio : Repositorio<TurnoServicio>, ITurnoServicioRepositorio
    {
        public TurnoServicioRepositorio(Context context) : base(context)
        {
        }
    }
}
