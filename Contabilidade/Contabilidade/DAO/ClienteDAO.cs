using Contabilidade.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contabilidade.DAO
{
    /* DAO
      A Função das classes DAO é armazenar as logicas de acesso ao banco de dados,
      como consultas e scripts sql e logica de persistencia de classes(model).
      Os metodos do DAO normalmente são acessados via classe Service.
    */
    public class ClienteDAO
    {
        private ConexaoSQLServerContext db = new ConexaoSQLServerContext();

        public Cliente findById(int id)
        {
            return db.Cliente.Find(id);
        }

        public void saveCliente(Cliente cliente)
        {
            db.Cliente.Add(cliente);
            db.SaveChanges();
        }

        public void updateCliente(Cliente cliente)
        {
            db.Entry(cliente).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void deleteCliente(int id)
        {
            db.Cliente.Remove(findById(id));
            db.SaveChanges();
        }
        public List<Cliente> getAllClientes()
        {
            return db.Cliente.ToList();
        }
    }
}