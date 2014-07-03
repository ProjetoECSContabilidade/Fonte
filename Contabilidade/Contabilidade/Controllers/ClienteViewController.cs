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
 
    public class ClienteViewController : BootstrapBaseController
    {
        private ConexaoSQLServerContext db = new ConexaoSQLServerContext();
        private ClienteService clienteService = new ClienteService();
        private SetorService setorService = new SetorService();

        //
        // GET: /Cliente/

        public ActionResult Index()
        {
            return View(clienteService.getAllClientes());
        }

        //
        // GET: /Cliente/Details/5

        public ActionResult Details(int id = 0)
        {
            ClienteView cliente = clienteService.findViewById(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // GET: /Cliente/Create

        public ActionResult Create()
        {
            ClienteView cView = new ClienteView();

            //var list = setorService.getAllSetoresAsList();
            //ViewBag.Setores = new MultiSelectList(list, "Id", "Descricao");

            //Assume some selected values returned from DB
            cView.SelectedCars = new string[] { "1", "2" };
            //Also the list of all cars
            cView.AllCars = GetAllCars();

            return View(cView);
        }
        private IEnumerable<SelectListItem> GetAllCars()
        {
            List<SelectListItem> allCars = new List<SelectListItem>();
            //Add a few cars to make a list of cars
            allCars.Add(new SelectListItem { Value = "1", Text = "BMW M3 Coupe" });
            allCars.Add(new SelectListItem { Value = "2", Text = "Aston Martin DB9" });
            allCars.Add(new SelectListItem { Value = "3", Text = "Lamborghini Aventador" });
            allCars.Add(new SelectListItem { Value = "4", Text = "Maserati Quattroporte" });
            allCars.Add(new SelectListItem { Value = "5", Text = "Audi R8" });
            allCars.Add(new SelectListItem { Value = "6", Text = "Mercedes SLS" });
            allCars.Add(new SelectListItem { Value = "7", Text = "Pagani Zonda R" });
            allCars.Add(new SelectListItem { Value = "8", Text = "Nissan GTR" });

            return allCars.AsEnumerable();
        }

        //
        // POST: /Cliente/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteView cliente)
        {
            if (ModelState.IsValid)
            {
                clienteService.saveCliente(cliente);
                return RedirectToAction("Index");
            }

            return View(cliente);
        }

        //
        // GET: /Cliente/Edit/5

        public ActionResult Edit(int id = 0)
        {
            ClienteView cliente = clienteService.findViewById(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // POST: /Cliente/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClienteView cliente)
        {
            if (ModelState.IsValid)
            {
                clienteService.atualizaCliente(cliente);
                return RedirectToAction("Index");
            }
            return View(cliente);
        }

        //
        // GET: /Cliente/Delete/5

        public ActionResult Delete(int id = 0)
        {
            ClienteView cliente = clienteService.findViewById(id);
            if (cliente == null)
            {
                return HttpNotFound();
            }
            return View(cliente);
        }

        //
        // POST: /Cliente/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            clienteService.deleteCliente(id);
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