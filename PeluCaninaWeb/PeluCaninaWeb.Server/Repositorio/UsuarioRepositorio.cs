using PeluCaninaWeb.BD.Data;
using PeluCaninaWeb.BD.Data.Entity;

namespace PeluCaninaWeb.Server.Repositorio
{
    public class UsuarioRepositorio : Repositorio<Usuario>, IUsuarioRepositorio
    {
        public UsuarioRepositorio(Context context) : base(context)
        {
        }
    }
}
