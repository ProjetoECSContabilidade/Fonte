using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contabilidade.Models;
using BootstrapMvcSample.Controllers;
using Contabilidade.DAO;
using Contabilidade.ViewModel;
using Contabilidade.Service;

namespace Contabilidade.Controllers
{
    public class UsuarioViewController : BootstrapBaseController
    {
        private ConexaoSQLServerContext db = new ConexaoSQLServerContext();
        private UsuarioService usuarioService = new UsuarioService();
        private SetorService setorService = new SetorService();

         // GET: /Usuario/
        public ActionResult Index()
        {
            return View(usuarioService.getAllUsuarios());
        }

        // GET: /Usuario/Details/5

        public ActionResult Details(int id = 0)
        {
            UsuarioView usuarioView = usuarioService.getUsuarioViewByUsuarioId(id);
            if (usuarioView == null)
            {
                return HttpNotFound();
            }
            return View("Create", usuarioView);
        }

        //
        // GET: /Usuario/Create

        public ActionResult Create()
        {
            var usuarioView = new UsuarioView
            {
                SetorList = setorService.getAllSetoresAsList()
            };

            return View(usuarioView);
        }
        
        
        // POST: /Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UsuarioView usuarioView)
        {
            //TODO tratar exceção quando inclui usuario com username duplicado
            if (ModelState.IsValid)
            {
                usuarioService.saveUsuario(usuarioView);
                return RedirectToAction("Index");
            }

            return View(usuarioView);
        }

        
        // GET: /Usuario/Edit/5
        public ActionResult Edit(int id = 0)
        {
            UsuarioView usuarioView = usuarioService.getUsuarioViewByUsuarioId(id);
            if (usuarioView == null)
            {
                return HttpNotFound();
            }
            return View("Create", usuarioView);
        }

        
        // POST: /Usuario/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UsuarioView usuarioView)
        {
            if (ModelState.IsValid)
            {
                usuarioService.atualizaUsuario(usuarioView);
                return RedirectToAction("Index");
            }
            return View(usuarioView);
        }

        //
        // GET: /Usuario/Delete/5

        public ActionResult Delete(int id = 0)
        {
            UsuarioView usuarioView = usuarioService.getUsuarioViewByUsuarioId(id);
            if (usuarioView == null)
            {
                return HttpNotFound();
            }

            return View(usuarioView);
        }

        //
        // POST: /Usuario/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            usuarioService.deleteUsuario(id);
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