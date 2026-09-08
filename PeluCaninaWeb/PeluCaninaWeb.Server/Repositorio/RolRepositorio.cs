using PeluCaninaWeb.BD.Data;
using PeluCaninaWeb.BD.Data.Entity;

namespace PeluCaninaWeb.Server.Repositorio
{
    public class RolRepositorio : Repositorio<Rol>, IRolRepositorio
    {
        public RolRepositorio(Context context) : base(context)
        {
        }
    }
}
