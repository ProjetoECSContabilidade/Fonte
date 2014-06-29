using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contabilidade.Models;
using Contabilidade.ViewModel;
using Contabilidade.Service;

namespace Contabilidade.Controllers
{
    /*	CONTROLLER
      A função das classes Controller é armazenas a logica de negocio e de apresentação,
      é a primeira classe que é chamada por uma tela, seja ela de cadastro ou somente apresentação de dados.
      Normalmente utiliza os metodos do Service para manipular os dados.
    */
 
    public class OrdemDeServicoViewController : Controller
    {
        private ConexaoSQLServerContext db = new ConexaoSQLServerContext();
        private OrdemDeServicoService osService = new OrdemDeServicoService();

        //
        // GET: /OrdemDeServico/

        public ActionResult Index()
        {
            DateTime MyDateTime = Convert.ToDateTime("01/05/2014");
            DateTime MyDateTime2 = Convert.ToDateTime("25/06/2014");
            DateTime MyDateTime3 = Convert.ToDateTime("11/07/2014");
            //MyDateTime = DateTime.Now;
            //MyDateTime = Convert.ToDateTime("01/05/2014");
            List<OrdemDeServicoView> listaDeOrdemDeServicoView = new List<OrdemDeServicoView>();

            OrdemDeServicoView os1 = new OrdemDeServicoView
            {
                Gcliente = "Dunzer Contabilidade",
                Gresponsavel = "Rubia",
                DataEntrega = MyDateTime,
                Status = "Concluido",
                GStatus = true
            };

            OrdemDeServicoView os2 = new OrdemDeServicoView
            {
                Gcliente = "Dunzer Contabilidade",
                Gresponsavel = "Rubia",
                DataEntrega = MyDateTime2,
                Status = "Não Concluido",
                GStatus = false
            };

            OrdemDeServicoView os3 = new OrdemDeServicoView
            {
                Gcliente = "Romaço",
                Gresponsavel = "Sandro",
                DataEntrega = MyDateTime3,
                Status = "Não Concluido",
                GStatus = false
            };

            listaDeOrdemDeServicoView.Add(os1);
            listaDeOrdemDeServicoView.Add(os2);
            listaDeOrdemDeServicoView.Add(os3);

            return View(listaDeOrdemDeServicoView);
        }

        //
        // GET: /OrdemDeServico/Details/5

        public ActionResult Details(int id = 0)
        {
            OrdemDeServicoView ordemdeservico = osService.findViewById(id);
                
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
        public ActionResult Create(OrdemDeServicoView ordemdeservicoView)
        {
            if (ModelState.IsValid)
            {
                osService.saveOrdemDeServico(ordemdeservicoView);
                return RedirectToAction("Index");
            }

            return View(ordemdeservicoView);
        }

        //
        // GET: /OrdemDeServico/Edit/5

        public ActionResult Edit(int id = 0)
        {
            OrdemDeServicoView osView = osService.findViewById(id);
            if (osView == null)
            {
                return HttpNotFound();
            }
            return View(osView);
        }

        //
        // POST: /OrdemDeServico/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrdemDeServicoView osView)
        {
            if (ModelState.IsValid)
            {
                osService.atualizaOrdemDeServico(osView);
                return RedirectToAction("Index");
            }
            return View(osView);
        }

        //
        // GET: /OrdemDeServico/Delete/5

        public ActionResult Delete(int id = 0)
        {
            OrdemDeServicoView osView= osService.findViewById(id);
            if (osView == null)
            {
                return HttpNotFound();
            }
            return View(osView);
        }

        //
        // POST: /OrdemDeServico/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            osService.deleteOrdemDeServico(id);
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