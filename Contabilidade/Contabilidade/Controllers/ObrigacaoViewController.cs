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
    public class ObrigacaoViewController : BootstrapBaseController
    {
        private ConexaoSQLServerContext db = new ConexaoSQLServerContext();
        private ObrigacaoService obrigacaoService = new ObrigacaoService();
        private SetorService setorService = new SetorService();
        
        // GET: /Obrigacao/
        public ActionResult Index()
        {
            return View(obrigacaoService.getAllObrigacoes());
            //List<Obrigacao> listaDeObrigacao = db.Obrigacao.ToList();
            ////@TODO refatorar para ficar mais performatico
            //foreach (Obrigacao obrigacao in listaDeObrigacao)
            //{
            //    obrigacao.Setor = db.Setor.Find(obrigacao.SetorId);
            //}

            //return View(listaDeObrigacao);
        }

        
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