using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Inventario.Clases;
using Inventario.Context;
using Inventario.Models;

namespace Inventario.Controllers
{
    public class ProductosController : Controller
    {
        private InventarioContext db;

        public ProductosController()
        {
            db = new InventarioContext();
        }

        // GET: Productos
        public ActionResult Index()
        {
            return View(db.Productos.OrderBy(p => p.Nombre).ToList());
        }

        // GET: Productos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //Producto producto = db.Productos.Find(id);
            var producto = db.Productos.Find(id);

            if (producto == null)
            {
                return HttpNotFound();
            }

            return View(producto);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "IDProducto,Cantidad,Nombre,Descripcion,Imagen")] Producto producto)
        public ActionResult Create(ProductoView view)
        {
            if (ModelState.IsValid)
            {
                var pic = string.Empty;
                var folder = "~/Content/Imagen";

                if (view.ImageFile != null)
                {
                    pic = FilesHelper.UploadPhoto(view.ImageFile, folder);
                    pic = string.Format("{0}/{1}", folder, pic);
                }

                var producto = ToProducto(view);
                producto.Imagen = pic;
                db.Productos.Add(producto);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(view);
        }

        private Producto ToProducto(ProductoView view)
        {
            return new Producto
            {
                Cantidad = view.Cantidad,
                IDProducto = view.IDProducto,
                Nombre = view.Nombre,
                Descripcion = view.Descripcion,
                Precio = view.Precio,
                Imagen = view.Imagen
            };
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var producto = db.Productos.Find(id);

            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(ToView(producto));
        }

        private ProductoView ToView(Producto producto)
        {
            return new ProductoView
            {
                Cantidad = producto.Cantidad,
                IDProducto = producto.IDProducto,
                Nombre = producto.Nombre,
                Descripcion = producto.Descripcion,
                Precio = producto.Precio,
                Imagen = producto.Imagen
            };
        }

        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductoView view)
        {
            if (ModelState.IsValid)
            {
                var pic = view.Imagen;
                var folder = "~/Content/Imagen";

                if (view.ImageFile != null)
                {
                    pic = FilesHelper.UploadPhoto(view.ImageFile, folder);
                    pic = string.Format("{0}/{1}", folder, pic);
                }

                var producto = ToProducto(view);
                producto.Imagen = pic;
                db.Entry(producto).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(view);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Producto producto = db.Productos.Find(id);
            if (producto == null)
            {
                return HttpNotFound();
            }
            return View(producto);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Producto producto = db.Productos.Find(id);
            db.Productos.Remove(producto);
            db.SaveChanges();
            return RedirectToAction("Index");
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
