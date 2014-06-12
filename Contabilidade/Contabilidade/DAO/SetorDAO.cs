using Contabilidade.Models;
using System;
using System.Collections.Generic;
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


        public Setor findById(int id)
        {
            return db.Setor.Find(id);
        }

    }
}