using PeluCaninaWeb.BD.Data;
using PeluCaninaWeb.BD.Data.Entity;

namespace PeluCaninaWeb.Server.Repositorio
{
    public class ServicioRepositorio : Repositorio<Servicio>, IServicioRepositorio
    {
        public ServicioRepositorio(Context context) : base(context)
        {
        }
    }
}
