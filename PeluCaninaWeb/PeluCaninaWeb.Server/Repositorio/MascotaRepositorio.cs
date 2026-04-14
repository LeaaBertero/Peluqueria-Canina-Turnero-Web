using PeluCaninaWeb.BD.Data;
using PeluCaninaWeb.BD.Data.Entity;

namespace PeluCaninaWeb.Server.Repositorio
{
    public class MascotaRepositorio : Repositorio<Mascota>, IMascotaRepositorio
    {
        public MascotaRepositorio(Context context) : base(context)
        {
        }
    }
}
