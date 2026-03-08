using PeluCaninaWeb.BD.Data;
using PeluCaninaWeb.BD.Data.Entity;

namespace PeluCaninaWeb.Server.Repositorio
{
    public class TurnoRepositorio : Repositorio<Turno>, ITurnoRepositorio
    {
        public TurnoRepositorio(Context context) : base(context)
        {

        }
    
    }
}
