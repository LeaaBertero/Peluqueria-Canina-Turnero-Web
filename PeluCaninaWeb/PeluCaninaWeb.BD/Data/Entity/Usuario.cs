using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluCaninaWeb.BD.Data.Entity
{
    public class Usuario : EntityBase
    {
        #region clave primaria
        public int UduarioId { get; set; }
        #endregion

        #region atributos
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1}")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "El apellido es obligatorio")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1}")]
        public string? Apellido { get; set; }

        [Required(ErrorMessage = "El mail es obligatorio")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1}")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "La contraseña es obligatorio")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1}")]
        public string? Contrasenia { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1}")]
        public string? Telefono { get; set; }
        public int Rol { get; set; }
        #endregion
    }
}
