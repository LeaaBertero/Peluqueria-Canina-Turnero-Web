using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluCaninaWeb.BD.Data.Entity
{
    public class TurnoServicio : EntityBase
    {
        #region claves relacionadas - tabla intermedia
        public int TurnoId { get; set; }
        public int ServicioId { get; set; }
        #endregion
    }
}
