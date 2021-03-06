﻿using Contabilidade.DAO;
using Contabilidade.Models;
using Contabilidade.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contabilidade.Service
{
    /* SERVICE
      A função das classes Service é armazenar metodos que podem ser reaproveitados pelo controller ou por outras classes em geral,
      Geralmente mediando a chamada de metodos entre controller e DAO.
      Normalmente contem a parte mais tecnica do projeto, como manipulação de objetos, listas, classes etc..
    */

    public class SetorService
    {
        private SetorDAO setorDAO = new SetorDAO();
        public Setor findById(int id)
        {
            return setorDAO.findById(id);
        }

        public IEnumerable<SelectListItem> getAllSetoresAsList()
        {
            return setorDAO.getAllSetoresAsList();
        }

        public List<SetorView> getAllSetores()
        {
            List<SetorView> listaDeSetorView = new List<SetorView>();
            List<Setor> listaDeSetores = setorDAO.getAllSetores();

            foreach (Setor usu in listaDeSetores)
            {
                listaDeSetorView.Add(transformSetorInSetorView(usu));
            }

            return listaDeSetorView;
        }

        private Setor transformSetorViewInSetor(SetorView setorView)
        {
            Setor setor = new Setor(setorView.Id,setorView.Descricao);

            return setor;
        }

        public SetorView transformSetorInSetorView(Setor setor)
        {
            SetorView sView = new SetorView(setor);
            return sView;
        }

        public SetorView getSetorViewBySetorId(int id)
        {
            return transformSetorInSetorView(findById(id));
        }

        public void saveSetor(SetorView sView)
        {
            Setor setor = transformSetorViewInSetor(sView);
            setorDAO.saveSetor(setor);
        }

        public void atualizaSetor(SetorView sView)
        {
            setorDAO.updateSetor(transformSetorViewInSetor(sView));
        }

        public void deleteSetor(int id)
        {
            setorDAO.deleteSetor(id);
        }

        public int getSetorIdBySetorDesc(string desc)
        {
            return setorDAO.getSetorIdBySetorDesc(desc);
        }
    }
}