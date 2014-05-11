using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contabilidade.Models;
using BootstrapMvcSample.Controllers;

namespace MvcApplication1.Controllers
{
    public class CrudController<Model> : BootstrapBaseController
    {
        private ConexaoSQLServerContext db = new ConexaoSQLServerContext();

        //
        // GET: /Model/

        public ActionResult Index()
        {

           List<Model> models =  (db.Set(typeof(Model)) as List<Model>);
            if (models == null)
                models = new List<Model>();
            return View(models.ToList());
        }

        //
        // GET: /Model/Details/5

        public ActionResult Details(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        //
        // GET: /Model/Create

        public ActionResult Create()
        {
            return View(Activator.CreateInstance<Model>());
    
        }

        //
        // POST: /Model/Create

        [HttpPost]
       // [ValidateAntiForgeryToken]
        public ActionResult Create(Model model)
        {
            //DbSet modelDBSet = db.Set(typeof(Model));
            if (ModelState.IsValid)
            {
                //Pega do set um model do mesmo tipo recebido por parametro else executa o add
                db.Set(typeof(Model)).Add(model);
                //db.modelDBSet.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(model);
        }

        //
        // GET: /Model/Edit/5

        public ActionResult Edit(int id)
        {
            Model instance = (Model)db.Set(typeof(Model)).Find(id);
            //Usuario usuario = db.Usuarios.Find(id);
            if (instance == null)
            {
                return HttpNotFound();
            }
            return View("Create", instance);

        }

        //
        // POST: /Usuario/Edit/5

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        //
        // GET: /Usuario/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario != null)
            {
                db.Usuario.Remove(usuario);
                db.SaveChanges();
                Attention("Apagou caralho");
            }
            return RedirectToAction("Index");
        }

        //
        // POST: /Usuario/Delete/5
        
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}