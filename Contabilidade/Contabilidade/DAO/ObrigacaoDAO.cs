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
    public class ObrigacaoDAO
    {
        private ConexaoSQLServerContext db = new ConexaoSQLServerContext();

        public void saveObrigacao(Obrigacao obrigacao)
        {
            db.Obrigacao.Add(obrigacao);
            db.SaveChanges();
        }

        public Obrigacao findById(int id)
        {
            return db.Obrigacao.Find(id);
        }

        public void updateObrigacao(Obrigacao obrigacao)
        {
            db.Entry(obrigacao).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void deleteObrigacao(int id)
        {
            db.Obrigacao.Remove(findById(id));
            db.SaveChanges();
        }

        public List<Obrigacao> getAllObrigacoes()
        {
            return db.Obrigacao.ToList();
        }
    }
}