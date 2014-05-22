using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Contabilidade.Models;
using BootstrapMvcSample.Controllers;

namespace Contabilidade.Controllers
{
    public class UsuarioController : BootstrapBaseController
    {
        private ConexaoSQLServerContext db = new ConexaoSQLServerContext();

        //
        // GET: /Usuario/

        public ActionResult Index()
        {
            List<Usuario> listaDeUsuario = db.Usuario.ToList();
            //@TODO refatorar para ficar mais performatico
            foreach(Usuario usu in listaDeUsuario){
                usu.Setor = db.Setor.Find(usu.SetorId);
            }

            return View(listaDeUsuario);
        }

        //
        // GET: /Usuario/Details/5

        public ActionResult Details(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            
            usuario.SetorList = GetAllSetoresAsList();
            
            return View("Create", usuario);
        }

        //
        // GET: /Usuario/Create

        public ActionResult Create()
        {
            //cria usuario sentando a lista de setor para ser apresentada no DropDownList
            var usuario = new Usuario
            {
                SetorList = GetAllSetoresAsList()
            };
            //END carregou lista de setores

            //carrega todos os setores na viewbag
            //var query = db.Setor.Select(s => new { Id = s.Id, s.Descricao });
            //ViewBag.Setores = new SelectList(query.AsEnumerable(), "Id", "Descricao");

            return View(usuario);
        }

        private IEnumerable<SelectListItem> GetAllSetoresAsList()
        {
            //BEGIN carregando a lista de setores
            var query = db.Setor.ToList().Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Descricao,
            });
            return query.AsEnumerable();
        }

        //
        // POST: /Usuario/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuario)
        {
            //TODO tratar exceção quando inclui usuario com username duplicado
            if (ModelState.IsValid)
            {
                db.Usuario.Add(usuario);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(usuario);
        }

        //
        // GET: /Usuario/Edit/5

        public ActionResult Edit(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }

            usuario.SetorList = GetAllSetoresAsList();

            return View("Create", usuario);
        }

        //
        // POST: /Usuario/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                db.Entry(usuario).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(usuario);
        }

        //
        // GET: /Usuario/Delete/5

        public ActionResult Delete(int id = 0)
        {
            Usuario usuario = db.Usuario.Find(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }

            usuario.SetorList = GetAllSetoresAsList();

            return View(usuario);
        }

        //
        // POST: /Usuario/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Usuario usuario = db.Usuario.Find(id);
            db.Usuario.Remove(usuario);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}