using Contabilidade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Contabilidade.Repositories
{
    public class UsuarioRepositorio
    {
        
        public static bool AutenticarUsuario(string Login, string Senha)
        {
            ConexaoSQLServerContext db = new ConexaoSQLServerContext();
            //DBAutEntities entities = new DBAutEntities();
            var Query = (from u in db.Usuario
                         where u.Login == Login &&
                         u.Senha == Senha
                         select u).SingleOrDefault();

            if (Query == null)
                return false;

            FormsAuthentication.SetAuthCookie(Query.Login, false);

            return true;
        }

        public static Usuario GetUsuarioLogado()
        {
            ConexaoSQLServerContext db = new ConexaoSQLServerContext();
            //pega o login do usuario logado
            string _Login = HttpContext.Current.User.Identity.Name;

            if (_Login == "")
            {
                return null;
            }
            else
            {
                Usuario user = (from u in db.Usuario
                                where u.Login == _Login 
                                select u).FirstOrDefault();

                return user;
            }
        }

        public static void Deslogar()
        {
            FormsAuthentication.SignOut();
        }
    }
}