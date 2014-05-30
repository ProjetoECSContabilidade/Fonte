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
    public class RelatorioOSController : BootstrapBaseController
    {
        private ConexaoSQLServerContext db = new ConexaoSQLServerContext();

        //
        // GET: /RelatorioOS/

        public ActionResult Create()
        {
            return View(new RelatorioOS());
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

        public ActionResult Start()
        {
            return RedirectToAction("Create");
        }
    }
}