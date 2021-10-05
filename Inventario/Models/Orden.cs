using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Inventario.Models
{
    public class Orden
    {
        [Key]
        public int OrdenID { get; set; }
        public DateTime FechaOrden { get; set; }
        public int ClienteID { get; set; }
        public string ClienteNombre { get; set; }

        public virtual ICollection<OrdenDetalles> OrdenesDetalles { get; set; }
    }
}