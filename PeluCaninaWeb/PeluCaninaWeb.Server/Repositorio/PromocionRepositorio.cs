using PeluCaninaWeb.BD.Data;
using PeluCaninaWeb.BD.Data.Entity;

namespace PeluCaninaWeb.Server.Repositorio
{
    public class PromocionRepositorio : Repositorio<Promocion>, IPromocionRepositorio
    {
        public PromocionRepositorio(Context context) : base(context)
        {
        }
    }
}
