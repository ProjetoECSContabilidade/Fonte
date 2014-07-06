using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contabilidade.Models;
using BootstrapMvcSample.Controllers;
using Contabilidade.Service;
using Contabilidade.ViewModel;

namespace Contabilidade.Controllers
{
    /*	CONTROLLER
      A função das classes Controller é armazenas a logica de negocio e de apresentação,
      é a primeira classe que é chamada por uma tela, seja ela de cadastro ou somente apresentação de dados.
      Normalmente utiliza os metodos do Service para manipular os dados.
    */
 
    public class ObrigacaoViewController : BootstrapBaseController
    {
        private ConexaoSQLServerContext db = new ConexaoSQLServerContext();
        private ObrigacaoService obrigacaoService = new ObrigacaoService();
        private SetorService setorService = new SetorService();
        
        // GET: /Obrigacao/
        public ActionResult Index(string searchDesc,string searchSetor, int? searchDia)
        {
            if (!String.IsNullOrEmpty(searchDesc) || !String.IsNullOrEmpty(searchSetor) || (searchDia != null && searchDia !=0) )
            {
                return View(obrigacaoService.searchObrigacaoComFiltro(searchDesc, searchSetor,searchDia));
            }
            else
            {
                return View(obrigacaoService.getAllObrigacoesAsView());
            }
            
        }

        //public ActionResult Index()
        //{
        //    return View(obrigacaoService.getAllObrigacoes());
        //}


        
        // GET: /Obrigacao/Create
        public ActionResult Create()
        {
            var obrigacaoView = new ObrigacaoView
            {
                SetorList = setorService.getAllSetoresAsList()
            };
            return View(obrigacaoView);
        }

        // POST: /Obrigacao/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ObrigacaoView obrigacaoView)
        {
            if (ModelState.IsValid)
            {
                obrigacaoService.saveObrigacao(obrigacaoView);
                return RedirectToAction("Index");
            }

            return View(obrigacaoView);
        }

        // GET: /Obrigacao/Edit/5
        public ActionResult Edit(int id = 0)
        {
            ObrigacaoView obrigacaoView = obrigacaoService.getObrigacaoViewByObrigacaoId(id);
            if (obrigacaoView == null)
            {
                return HttpNotFound();
            }
            return View("Create", obrigacaoView);
        }

        // POST: /Obrigacao/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ObrigacaoView obrigacaoView)
        {
            if (ModelState.IsValid)
            {
                obrigacaoService.atualizaObrigacao(obrigacaoView);
                return RedirectToAction("Index");
            }
            return View(obrigacaoView);
        }


        // GET: /Obrigacao/Delete/5
        public ActionResult Delete(int id = 0)
        {
            ObrigacaoView obrigacaoView = obrigacaoService.getObrigacaoViewByObrigacaoId(id);
            if (obrigacaoView == null)
            {
                return HttpNotFound();
            }

            return View(obrigacaoView);
        }

        // POST: /Obrigacao/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            obrigacaoService.deleteObrigacao(id);
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