using Inventario.Context;
using Inventario.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventario.Controllers
{
    public class OrdenesController : Controller
    {
        InventarioContext db = new InventarioContext();

        // GET: Ordenes
        public ActionResult NuevaOrden()
        {
            var ordenView = new OrdenView();
            ordenView.Orden = new Orden();
            ordenView.Productos = new List<ProductoOrden>();

            return View(ordenView);
        }

        [HttpPost]
        public ActionResult NuevaOrden(OrdenView ordenView)
        {
            return View(ordenView);
        }

        public ActionResult SelectProducto(ProductoOrden productoOrden)
        {
            var list = db.Productos.ToList();
            list.Add(new ProductoOrden { IDProducto = 0, Nombre = "[Seleccione un producto...]" });
            list = list.OrderBy(p => p.Nombre).ToList();
            ViewBag.IDProducto = new SelectList(list, "IDProducto", "Nombre");

            return View(productoOrden);
        }

        [HttpPost]
        public ActionResult SelectProducto(FormCollection form)
        {
            var list = db.Productos.ToList();
            list.Add(new ProductoOrden { IDProducto = 0, Nombre = "[Seleccione un producto...]" });
            list = list.OrderBy(p => p.Nombre).ToList();
            ViewBag.IDProducto = new SelectList(list, "IDProducto", "Nombre");

            return View();
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}