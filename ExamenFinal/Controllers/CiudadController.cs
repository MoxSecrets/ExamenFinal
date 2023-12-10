using ExamenFinal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamenFinal.Controllers
{
    public class CiudadController : Controller
    {

        private readonly DbModels _context;

        public CiudadController()
        {
            _context = new DbModels();
        }

        // GET: Ciudad
        public ActionResult Index()
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Ciudad.ToList());
            }
        }

        // GET: Ciudad/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Ciudad.FirstOrDefault(x => x.id == id));
            }
        }

        // GET: Ciudad/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Ciudad/Create
        [HttpPost]
        public ActionResult Create(Ciudad ciudad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DbModels context = new DbModels())
                    {
                        context.Ciudad.Add(ciudad);
                        context.SaveChanges();
                    }

                    TempData["Mensaje"] = "Ciudad agregada exitosamente.";
                    return RedirectToAction("Index");
                }
                return View(ciudad);
            }
            catch
            {
                return View();
            }
        }

        // GET: Ciudad/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Ciudad.Where(x => x.id == id).FirstOrDefault());
            }
        }

        // POST: Ciudad/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Ciudad ciudad)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DbModels context = new DbModels())
                    {
                        context.Entry(ciudad).State = EntityState.Modified;
                        context.SaveChanges();
                    }

                    TempData["Mensaje"] = "Ciudad editada exitosamente.";
                    return RedirectToAction("Index");
                }
                return View(ciudad);
            }
            catch
            {
                return View();
            }
        }

        // GET: Ciudad/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Ciudad.Where(x => x.id == id).FirstOrDefault());
            }
        }

        // POST: Ciudad/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    Ciudad ciudad = context.Ciudad.Where(x => x.id == id).FirstOrDefault();
                    context.Ciudad.Remove(ciudad);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Reporte
        public ActionResult ReporteClientesPorCiudad()
        {
            var reporte = _context.Ciudad
                .GroupJoin(_context.Cliente,
                    ciudad => ciudad.id,
                    cliente => cliente.CiudadId,
                    (ciudad, clientes) => new ReporteCiudadViewModel
                    {
                        Ciudad = ciudad.nombre,
                        CantidadClientes = clientes.Count()
                    })
                .ToList();

            ViewBag.ReporteClientesPorCiudad = reporte;

            return View(reporte);
        }
    }
}
