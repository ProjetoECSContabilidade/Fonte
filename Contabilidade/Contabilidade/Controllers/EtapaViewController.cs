using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contabilidade.Models;
using Contabilidade.Service;
using Contabilidade.ViewModel;

namespace Contabilidade.Controllers
{
    /*	CONTROLLER
      A função das classes Controller é armazenas a logica de negocio e de apresentação,
      é a primeira classe que é chamada por uma tela, seja ela de cadastro ou somente apresentação de dados.
      Normalmente utiliza os metodos do Service para manipular os dados.
    */
 
    public class EtapaViewController : Controller
    {
        private ConexaoSQLServerContext db = new ConexaoSQLServerContext();
        private EtapaService etapaService = new EtapaService();

        //
        // GET: /Etapa/

        public ActionResult Index()
        {
            return ListarEtapas(1);
        }

        public ActionResult ListarEtapas(int id)
        {
            ViewBag.IdDaOS = id;
            return View("Index", etapaService.getEtapasByOSId(id));
        }

        //
        // GET: /Etapa/Edit/5

        public ActionResult Edit(int id = 0)
        {
            EtapaView etapa = etapaService.findViewById(id);
            if (etapa == null)
            {
                return HttpNotFound();
            }
            return View(etapa);
        }

        //
        // POST: /Etapa/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Etapa etapa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(etapa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(etapa);
        }

        //
        // GET: /Etapa/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Etapa etapa = db.Etapa.Find(id);
            if (etapa == null)
            {
                return HttpNotFound();
            }
            return View(etapa);
        }

        //
        // POST: /Etapa/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Etapa etapa = db.Etapa.Find(id);
            db.Etapa.Remove(etapa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
        public ActionResult Start()
        {
            return RedirectToAction("Index");
        }

    }
}