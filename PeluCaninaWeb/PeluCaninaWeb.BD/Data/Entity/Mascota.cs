using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluCaninaWeb.BD.Data.Entity
{
    public class Mascota : EntityBase
    {
        public int MascotaId { get; set; }
        public int UsuarioId { get; set; }

        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1}")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "La Edad es obligatoria")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1}")]
        public string? Edad { get; set; }


        [Required(ErrorMessage = "El peso es obligatorio")]
        public decimal? Peso { get; set; }

        [Required(ErrorMessage = "La Descripción es obligatoria")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1}")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "La especie es obligatoria")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1}")]
        public string? Especie { get; set; }

        [Required(ErrorMessage = "La Raza es obligatoria")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1}")]
        public string? Raza { get; set; }
    }
}
