using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Inventario.Models
{
    public class Producto
    {
        [Key]
        public int IDProducto { get; set; }

        [Required(ErrorMessage = "Ingrese la {0} de producto")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Ingrese el {0} de producto")]
        [StringLength(20, ErrorMessage = "El campo {0} no puede ser mayor a {1}")]
        public string Nombre { get; set; }

        [Required(ErrorMessage = "Ingrese la {0} de producto")]
        [DataType(DataType.MultilineText)]
        public string Descripcion { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "Ingrese el {0} de producto")]
        public decimal Precio { get; set; }

        public string Imagen { get; set; }

        public virtual ICollection<OrdenDetalles> OrdenesDetalles { get; set; }
    }
}