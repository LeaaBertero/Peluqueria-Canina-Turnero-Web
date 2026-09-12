using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluCaninaWeb.BD.Data.Entity
{
    public class Mascota : EntityBase
    {
        #region clave primaria
        public int MascotaId { get; set; }
        #endregion

        #region clave foranea
        public int UsuarioId { get; set; }
        #endregion

        #region atributos de la entidad
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1}")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "La Edad es obligatoria")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1}")]
        public string? Edad { get; set; }


        [Required(ErrorMessage = "El peso es obligatorio")]
        [Column(TypeName = "decimal(10,2)")]
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
        #endregion
    }
}
