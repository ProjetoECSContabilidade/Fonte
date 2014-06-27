using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BootstrapMvcSample.Controllers
{
    /*	CONTROLLER
      A função das classes Controller é armazenas a logica de negocio e de apresentação,
      é a primeira classe que é chamada por uma tela, seja ela de cadastro ou somente apresentação de dados.
      Normalmente utiliza os metodos do Service para manipular os dados.
    */
 
    public class ExampleLayoutsController : Controller
    {
        public ActionResult Starter()
        {
            return View();
        }

        public ActionResult Marketing()
        {
            return View();
        }

        public ActionResult Fluid()
        {
            return View();
        }

        public ActionResult Narrow()
        {
            return View();
        }

        public ActionResult SignIn()
        {
            return View();
        }

        public ActionResult StickyFooter()
        {
            return View("TBD");
        }

        public ActionResult Carousel()
        {
            return View("TBD");
        }
    }
}
