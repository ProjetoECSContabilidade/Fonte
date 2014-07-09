using Contabilidade.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Contabilidade.DAO
{
    /* DAO
      A Função das classes DAO é armazenar as logicas de acesso ao banco de dados,
      como consultas e scripts sql e logica de persistencia de classes(model).
      Os metodos do DAO normalmente são acessados via classe Service.
    */
    public class OrdemDeServicoDAO
    {
        private ConexaoSQLServerContext db = new ConexaoSQLServerContext();

        public OrdemDeServico findById(int id)
        {
            return db.OrdemDeServico.Find(id);
        }

        public void saveOrdemDeServico(OrdemDeServico os)
        {
            db.OrdemDeServico.Add(os);
            db.SaveChanges();
        }

        public void updateOrdemDeServico(OrdemDeServico os)
        {
            db.Entry(os).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void deleteOrdemDeServico(int id)
        {
            db.OrdemDeServico.Remove(findById(id));
            db.SaveChanges();
        }

    }
}