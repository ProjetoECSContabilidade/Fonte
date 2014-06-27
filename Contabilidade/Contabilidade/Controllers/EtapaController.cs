using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contabilidade.Models;

namespace Contabilidade.Controllers
{
    /*	CONTROLLER
      A função das classes Controller é armazenas a logica de negocio e de apresentação,
      é a primeira classe que é chamada por uma tela, seja ela de cadastro ou somente apresentação de dados.
      Normalmente utiliza os metodos do Service para manipular os dados.
    */
 
    public class EtapaController : Controller
    {
        private ConexaoSQLServerContext db = new ConexaoSQLServerContext();

        //
        // GET: /Etapa/

        public ActionResult Index()
        {
            DateTime MyDateTime  = new DateTime();
            //MyDateTime = DateTime.Now;
            MyDateTime = Convert.ToDateTime("01/05/2014");
            List<Etapa> listaDeEtapa = new List<Etapa>();

            Etapa etapa1 = new Etapa{
                ObrigacaoString = "DIME",
                StatusString = "Concluido",
                DataEntrega = MyDateTime,
                ResponsavelString = "Rubia",
                Concluido = true
            };

            Etapa etapa2 = new Etapa
            {
                ObrigacaoString = "SPED CONTABIL",
                StatusString = "Aguardando Cliente",
                DataEntrega = MyDateTime,
                ResponsavelString = "Sandro",
                Concluido = false
            };

            listaDeEtapa.Add(etapa1);
            listaDeEtapa.Add(etapa2);


            return View(listaDeEtapa);
        }

        //
        // GET: /Etapa/Details/5

        public ActionResult Details(int id = 0)
        {
            Etapa etapa = db.Etapa.Find(id);
            if (etapa == null)
            {
                return HttpNotFound();
            }
            return View(etapa);
        }

        //
        // GET: /Etapa/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Etapa/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Etapa etapa)
        {
            if (ModelState.IsValid)
            {
                db.Etapa.Add(etapa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(etapa);
        }

        //
        // GET: /Etapa/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Etapa etapa = db.Etapa.Find(id);
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