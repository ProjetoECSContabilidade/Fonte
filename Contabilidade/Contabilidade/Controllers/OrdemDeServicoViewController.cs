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
        private ClienteService clienteService = new ClienteService();
        private UsuarioService usuarioService = new UsuarioService();
        private SetorService setorService = new SetorService();

        //
        // GET: /OrdemDeServico/

        public ActionResult Index(string searchIdResponsavel, string searchIdSetor, string searchIdCliente)
        {
            
            if (String.IsNullOrEmpty(searchIdResponsavel) || String.IsNullOrEmpty(searchIdSetor) || String.IsNullOrEmpty(searchIdCliente))
            {
                ViewBag.AllSetores = setorService.getAllSetoresAsList();
                ViewBag.AllUsuarios = usuarioService.getAllUsuariosAsList();
                ViewBag.AllClientes = clienteService.getAllClientesAsList();

                return View(osService.getAllOrdensDeServico());
            }
            else
            {
                //TODO IMPLEMENTAR FILTROS
                return View();
            }
            
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

        
        // GET: /Cliente/Create
        public ActionResult Create()
        {
            OrdemDeServicoView osView = new OrdemDeServicoView();
            osService.inicializaOSView(osView);

            return View(osView);
        }

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
            return View("Create", osView);
        }

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