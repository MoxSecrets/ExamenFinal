using ExamenFinal.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExamenFinal.Controllers
{
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Cliente.ToList());
            }
        }

        // GET: Cliente/Details/5
        public ActionResult Details(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Cliente.FirstOrDefault(x => x.id == id));
            }
        }

        // GET: Cliente/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Cliente/Create
        [HttpPost]
        public ActionResult Create(Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DbModels context = new DbModels())
                    {
                        context.Cliente.Add(cliente);
                        context.SaveChanges();
                    }

                    TempData["Mensaje"] = "Cliente agregado exitosamente.";
                    return RedirectToAction("Index");
                }
                return View(cliente);                
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Edit/5
        public ActionResult Edit(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Cliente.Where(x => x.id == id).FirstOrDefault());
            }
        }

        // POST: Cliente/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Cliente cliente)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (DbModels context = new DbModels())
                    {
                        context.Entry(cliente).State = EntityState.Modified;
                        context.SaveChanges();
                    }

                    TempData["Mensaje"] = "Cliente editado exitosamente.";
                    return RedirectToAction("Index");
                }
                return View(cliente);          
            }
            catch
            {
                return View();
            }
        }

        // GET: Cliente/Delete/5
        public ActionResult Delete(int id)
        {
            using (DbModels context = new DbModels())
            {
                return View(context.Cliente.Where(x => x.id == id).FirstOrDefault());
            }
        }

        // POST: Cliente/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                using (DbModels context = new DbModels())
                {
                    Cliente cliente = context.Cliente.Where(x => x.id == id).FirstOrDefault();
                    context.Cliente.Remove(cliente);
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
