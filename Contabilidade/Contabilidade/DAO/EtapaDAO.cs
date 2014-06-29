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
    public class EtapaDAO
    {
        private ConexaoSQLServerContext db = new ConexaoSQLServerContext();

        public Etapa findById(int id)
        {
            return db.Etapa.Find(id);
        }

        public void saveEtapa(Etapa etapa)
        {
            db.Etapa.Add(etapa);
            db.SaveChanges();
        }

        public void updateEtapa(Etapa etapa)
        {
            db.Entry(etapa).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void deleteEtapa(int id)
        {
            db.Etapa.Remove(findById(id));
            db.SaveChanges();
        }
    }
}