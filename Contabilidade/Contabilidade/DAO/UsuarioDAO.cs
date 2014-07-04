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
    /* DAO
      A Função das classes DAO é armazenar as logicas de acesso ao banco de dados,
      como consultas e scripts sql e logica de persistencia de classes(model).
      Os metodos do DAO normalmente são acessados via classe Service.
    */
    public class UsuarioDAO
    {
        private ConexaoSQLServerContext db = new ConexaoSQLServerContext();
        private SetorService setorService = new SetorService();

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

        public List<Usuario> selectUsuariosPorFiltro(string filtroNome, string filtroSetor, string filtroCargo)
        {
            var query = from u in db.Usuario
                        select u;

            int setorId = 0;

            if (!String.IsNullOrEmpty(filtroSetor))
            {
                setorId = setorService.getSetorIdBySetorDesc(filtroSetor);
            }

            if (!String.IsNullOrEmpty(filtroNome))
            {
                query = query.Where(u => u.Nome.Contains(filtroNome));
            }
            if (setorId != null && setorId != 0)
            {
                query = query.Where(s => s.SetorId == setorId);
            }
            if (!String.IsNullOrEmpty(filtroCargo))
            {
                query = query.Where(u => u.Cargo.Contains(filtroCargo));
            }

            query.Select(u => new Usuario
            {
                Id = u.Id,
                Login = u.Login,
                Nome = u.Nome,
                Cargo = u.Cargo,
                SetorId = u.SetorId,
                Email = u.Email,
                Ativo = u.Ativo
            });

            return query.ToList();
        }
    
    
    }

}