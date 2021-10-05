using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Inventario.Models
{
    public class OrdenView
    {
        public Orden Orden { get; set; }
        public List<ProductoOrden> Productos { get; set; }
    }
}