using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contabilidade.Models;
using Contabilidade.DAO;
using Contabilidade.ViewModel;
using Contabilidade.Service;
using System.Data;

namespace Contabilidade.DAO
{
    public class UsuarioDAO
    {
        private ConexaoSQLServerContext db = new ConexaoSQLServerContext();

        public void saveUsuario(Usuario usuario){
            db.Usuario.Add(usuario);
            db.SaveChanges();
        }

        public Usuario findById(int id){
               return db.Usuario.Find(id);
        }

        public void updateUsuario(Usuario usuario)
        {
            db.Entry(usuario).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void deleteUsuario(int id){
            db.Usuario.Remove(findById(id));
            db.SaveChanges();
        }

        public List<Usuario> getAllUsuarios()
        {
            return db.Usuario.ToList();
        }
    }
}