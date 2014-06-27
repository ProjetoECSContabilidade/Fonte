using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contabilidade.Models;
using BootstrapMvcSample.Controllers;
using Contabilidade.ViewModel;
using Contabilidade.Service;

namespace Contabilidade.Controllers
{
    /*	CONTROLLER
      A função das classes Controller é armazenas a logica de negocio e de apresentação,
      é a primeira classe que é chamada por uma tela, seja ela de cadastro ou somente apresentação de dados.
      Normalmente utiliza os metodos do Service para manipular os dados.
    */
    public class SetorViewController : BootstrapBaseController
    {
        private ConexaoSQLServerContext db = new ConexaoSQLServerContext();
        private SetorService setorService = new SetorService();


        // GET: /Setor/
        public ActionResult Index()
        {
            return View(setorService.getAllSetores());
        }

        // GET: /Setor/Details/5
        public ActionResult Details(int id = 0)
        {
            SetorView sView = setorService.getSetorViewBySetorId(id);
            if (sView == null)
            {
                return HttpNotFound();
            }
            return View(sView);
        }

        //
        // GET: /Setor/Create

        public ActionResult Create()
        {
            return View(new SetorView());
        }

        // POST: /Setor/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SetorView setorView)
        {
            if (ModelState.IsValid)
            {
                setorService.saveSetor(setorView);
                return RedirectToAction("Index");
            }

            return View(setorView);
        }

        // GET: /Setor/Edit/5
        public ActionResult Edit(int id = 0)
        {
            SetorView setorView = setorService.getSetorViewBySetorId(id);
            if (setorView == null)
            {
                return HttpNotFound();
            }
            return View("Create", setorView);
        }

        //
        // POST: /Setor/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SetorView setorView)
        {
            if (ModelState.IsValid)
            {
                setorService.atualizaUsuario(setorView);
                return RedirectToAction("Index");
            }
            return View(setorView);
        }

        //
        // GET: /Setor/Delete/5

        public ActionResult Delete(int id = 0)
        {
            SetorView setorView = setorService.getSetorViewBySetorId(id);
            if (setorView == null)
            {
                return HttpNotFound();
            }
            return View(setorView);
        }

        //
        // POST: /Setor/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            setorService.deleteSetor(id);
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