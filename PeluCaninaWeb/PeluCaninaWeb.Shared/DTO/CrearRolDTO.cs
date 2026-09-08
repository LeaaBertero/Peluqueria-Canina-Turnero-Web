using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluCaninaWeb.Shared.DTO
{
    public class CrearRolDTO
    {
        #region atributos
        [Required(ErrorMessage = "El nombre del rol es obligatorio")]
        [MaxLength(100, ErrorMessage = "Maximo número de caracteres {1}")]
        public string? NombreRol { get; set; }
        #endregion
    }
}
