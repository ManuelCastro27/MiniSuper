using System.ComponentModel.DataAnnotations;

namespace Inventario.Models
{
    public class OrdenDetalles
    {
        [Key]
        public int OrdenDetallesID { get; set; }
        public int OrdenID { get; set; }
        public int IDProducto { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "Ingrese la {0} de producto")]
        public float CantidadOrden { get; set; }

        [Required(ErrorMessage = "Ingrese el {0} de producto")]
        [StringLength(20, ErrorMessage = "El campo {0} no puede ser mayor a {1}")]
        public string Cliente { get; set; }

        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        [Required(ErrorMessage = "Ingrese la {0} de producto")]
        public decimal Precio { get; set; }

        public virtual Orden Orden { get; set; }
        public virtual Producto Producto { get; set; }
    }
}