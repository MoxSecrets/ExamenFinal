using ExamenFinal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamenFinal.Controllers
{
    public class CategoriaController : Controller
    {
        // GET: Categoria
        public ActionResult Index()
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Categoria.ToList());
            }
        }

        // GET: Categoria/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Categoria.FirstOrDefault(x => x.id == id));
            }
        }

        // GET: Categoria/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Categoria/Create
        [HttpPost]
        public ActionResult Create(Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DbModels context = new DbModels())
                    {
                        context.Categoria.Add(categoria);
                        context.SaveChanges();
                    }

                    TempData["Mensaje"] = "Categoría agregada exitosamente.";
                    return RedirectToAction("Index");
                }
                return View(categoria);
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Categoria.Where(x => x.id == id).FirstOrDefault());
            }
        }

        // POST: Categoria/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Categoria categoria)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DbModels context = new DbModels())
                    {
                        context.Entry(categoria).State = EntityState.Modified;
                        context.SaveChanges();
                    }

                    TempData["Mensaje"] = "Categoría modificada exitosamente.";
                    return RedirectToAction("Index");
                }

                return View(categoria);
            }
            catch
            {
                return View();
            }
        }

        // GET: Categoria/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Categoria.Where(x => x.id == id).FirstOrDefault());
            }
        }

        // POST: Categoria/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    Categoria categoria = context.Categoria.Where(x => x.id == id).FirstOrDefault();
                    context.Categoria.Remove(categoria);
                    context.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
