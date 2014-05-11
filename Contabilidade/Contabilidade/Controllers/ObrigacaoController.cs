using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contabilidade.Models;
using BootstrapMvcSample.Controllers;

namespace Contabilidade.Controllers
{
    public class ObrigacaoController : BootstrapBaseController
    {
        private ConexaoSQLServerContext db = new ConexaoSQLServerContext();

        //
        // GET: /Obrigacao/

        public ActionResult Index()
        {
            return View(db.Obrigacao.ToList());
        }

        //
        // GET: /Obrigacao/Details/5

        public ActionResult Details(int id = 0)
        {
            Obrigacao obrigacao = db.Obrigacao.Find(id);
            if (obrigacao == null)
            {
                return HttpNotFound();
            }
            return View(obrigacao);
        }

        //
        // GET: /Obrigacao/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Obrigacao/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Obrigacao obrigacao)
        {
            if (ModelState.IsValid)
            {
                db.Obrigacao.Add(obrigacao);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(obrigacao);
        }

        //
        // GET: /Obrigacao/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Obrigacao obrigacao = db.Obrigacao.Find(id);
            if (obrigacao == null)
            {
                return HttpNotFound();
            }
            return View(obrigacao);
        }

        //
        // POST: /Obrigacao/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Obrigacao obrigacao)
        {
            if (ModelState.IsValid)
            {
                db.Entry(obrigacao).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(obrigacao);
        }

        //
        // GET: /Obrigacao/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Obrigacao obrigacao = db.Obrigacao.Find(id);
            if (obrigacao == null)
            {
                return HttpNotFound();
            }
            return View(obrigacao);
        }

        //
        // POST: /Obrigacao/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Obrigacao obrigacao = db.Obrigacao.Find(id);
            db.Obrigacao.Remove(obrigacao);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}