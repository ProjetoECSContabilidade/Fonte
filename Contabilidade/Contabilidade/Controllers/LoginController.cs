using BootstrapMvcSample.Controllers;
using Contabilidade.Models;
using Contabilidade.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contabilidade.Controllers
{
    public class LoginController : BootstrapBaseController
    {
        [HttpPost]
        public ActionResult Logar(string usuario, string senha)
        {
            if (UsuarioRepositorio.AutenticarUsuario(usuario, senha) == false)
            {
                ViewBag.msg_Error = "O nome de usuário ou a senha infoamda estão incorrretos!";
            }

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }


        public ActionResult LogOut()
        {
            UsuarioRepositorio.Deslogar();
            return View("Login");
        }
    }
}