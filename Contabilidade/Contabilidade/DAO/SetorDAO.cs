using Contabilidade.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contabilidade.DAO
{
    public class SetorDAO
    {
        private ConexaoSQLServerContext db = new ConexaoSQLServerContext();

        public IEnumerable<SelectListItem> getAllSetoresAsList()
        {
            var query = db.Setor.ToList().Select(s => new SelectListItem
            {
                Value = s.Id.ToString(),
                Text = s.Descricao,
            });
            return query.AsEnumerable();
        }

        public List<Setor> getAllSetores()
        {
            return db.Setor.ToList();
        }


        public Setor findById(int id)
        {
            return db.Setor.Find(id);
        }

        public void saveSetor(Setor setor)
        {
            db.Setor.Add(setor);
            db.SaveChanges();
        }

        public void updateSetor(Setor setor)
        {
            db.Entry(setor).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void deleteSetor(int id)
        {
            db.Setor.Remove(findById(id));
            db.SaveChanges();
        }

    }
}