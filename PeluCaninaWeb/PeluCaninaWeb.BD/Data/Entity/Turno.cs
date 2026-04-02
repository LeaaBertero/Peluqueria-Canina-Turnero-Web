using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluCaninaWeb.BD.Data.Entity
{
    public class Turno : EntityBase
    {
        #region clave primaria
        public int TurnoId { get; set; }
        #endregion

        #region claves foraneas
        public int UsuarioId { get; set; }
        public int MascotaId { get; set; }
        #endregion

        #region atributos
        [Required(ErrorMessage = "La fecha del turno es obligatoria")]        
        public DateTime FechaHora { get; set; }

        public enum Estado { Disponible, NoDisponible  }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1}")]
        public string? Nota { get; set; }
        #endregion
    }
}
