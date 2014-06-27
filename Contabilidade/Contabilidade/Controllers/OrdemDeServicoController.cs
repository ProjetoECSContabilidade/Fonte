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
 
    public class OrdemDeServicoController : Controller
    {
        private ConexaoSQLServerContext db = new ConexaoSQLServerContext();

        //
        // GET: /OrdemDeServico/

        public ActionResult Index()
        {
            DateTime MyDateTime = Convert.ToDateTime("01/05/2014");
            DateTime MyDateTime2 = Convert.ToDateTime("25/06/2014");
            DateTime MyDateTime3 = Convert.ToDateTime("11/07/2014");
            //MyDateTime = DateTime.Now;
            //MyDateTime = Convert.ToDateTime("01/05/2014");
            List<OrdemDeServico> listaDeOrdemDeServico = new List<OrdemDeServico>();

            OrdemDeServico os1 = new OrdemDeServico
            {
                Gcliente = "Dunzer Contabilidade",
                Gresponsavel = "Rubia",
                DataEntrega = MyDateTime,
                status = "Concluido",
                GStatus = true
            };

            OrdemDeServico os2 = new OrdemDeServico
            {
                Gcliente = "Dunzer Contabilidade",
                Gresponsavel = "Rubia",
                DataEntrega = MyDateTime2,
                status = "Não Concluido",
                GStatus = false
            };

            OrdemDeServico os3 = new OrdemDeServico
            {
                Gcliente = "Romaço",
                Gresponsavel = "Sandro",
                DataEntrega = MyDateTime3,
                status = "Não Concluido",
                GStatus = false
            };

            listaDeOrdemDeServico.Add(os1);
            listaDeOrdemDeServico.Add(os2);
            listaDeOrdemDeServico.Add(os3);

            return View(listaDeOrdemDeServico);
        }

        //
        // GET: /OrdemDeServico/Details/5

        public ActionResult Details(int id = 0)
        {
            OrdemDeServico ordemdeservico = db.OrdemDeServico.Find(id);
            if (ordemdeservico == null)
            {
                return HttpNotFound();
            }
            return View(ordemdeservico);
        }

        //
        // GET: /OrdemDeServico/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /OrdemDeServico/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrdemDeServico ordemdeservico)
        {
            if (ModelState.IsValid)
            {
                db.OrdemDeServico.Add(ordemdeservico);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(ordemdeservico);
        }

        //
        // GET: /OrdemDeServico/Edit/5

        public ActionResult Edit(int id = 0)
        {
            OrdemDeServico ordemdeservico = db.OrdemDeServico.Find(id);
            if (ordemdeservico == null)
            {
                return HttpNotFound();
            }
            return View(ordemdeservico);
        }

        //
        // POST: /OrdemDeServico/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrdemDeServico ordemdeservico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ordemdeservico).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ordemdeservico);
        }

        //
        // GET: /OrdemDeServico/Delete/5

        public ActionResult Delete(int id = 0)
        {
            OrdemDeServico ordemdeservico = db.OrdemDeServico.Find(id);
            if (ordemdeservico == null)
            {
                return HttpNotFound();
            }
            return View(ordemdeservico);
        }

        //
        // POST: /OrdemDeServico/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            OrdemDeServico ordemdeservico = db.OrdemDeServico.Find(id);
            db.OrdemDeServico.Remove(ordemdeservico);
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