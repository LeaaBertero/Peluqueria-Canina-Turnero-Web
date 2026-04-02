using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluCaninaWeb.Shared.DTO
{
    public class CrearTurnoDTO
    {
        #region atributos
        [Required(ErrorMessage = "La fecha del turno es obligatoria")]
        public DateTime FechaHora { get; set; }

        public enum Estado { Disponible, NoDisponible }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1}")]
        public string? Nota { get; set; }
        #endregion
    }
}
