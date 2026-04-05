using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeluCaninaWeb.BD.Data.Entity
{
    public class Servicio : EntityBase
    {
        #region clave primaria
        public int ServicioId { get; set; }
        #endregion

        #region atributos de la entidad
        [Required(ErrorMessage = "El nombre es obligatorio")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1}")]
        public string? Nombre { get; set; }

        [Required(ErrorMessage = "La descripción es obligatoria")]
        [MaxLength(50, ErrorMessage = "Maximo número de caracteres {1}")]
        public string? Descripcion { get; set; }

        [Required(ErrorMessage = "El precio del servicio es obligatorio")]
        public decimal Precio { get; set; }
        #endregion
    }
}
