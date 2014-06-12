using Contabilidade.DAO;
using Contabilidade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contabilidade.Service
{
    public class SetorService
    {
        private SetorDAO setorDAO = new SetorDAO();
        public Setor findById(int id)
        {
            return setorDAO.findById(id);
        }

        public IEnumerable<SelectListItem> getAllSetores()
        {
            return setorDAO.getAllSetoresAsList();
        }
    }
}