using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluCaninaWeb.BD.Data.Entity
{
    public class Promocion : EntityBase
    {
        public int IdPromocion { get; set; }

        [Required(ErrorMessage = "El titulo es obligatorio")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1}")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "La Descripción es obligatoria")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1}")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "La fecha de inicio es obligatoria")]
        public DateOnly FechaInicio { get; set; }

        [Required(ErrorMessage = "La fecha de fin es obligatoria")]
        public DateOnly FechaFin { get; set; }

        public bool Activo { get; set; }
    }
}
