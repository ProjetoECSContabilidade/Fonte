using Contabilidade.DAO;
using Contabilidade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contabilidade.ViewModel;

namespace Contabilidade.Service
{
    /* SERVICE
      A função das classes Service é armazenar metodos que podem ser reaproveitados pelo controller ou por outras classes em geral,
      Geralmente mediando a chamada de metodos entre controller e DAO.
      Normalmente contem a parte mais tecnica do projeto, como manipulação de objetos, listas, classes etc..
    */

    public class OrdemDeServicoService
    {
        private OrdemDeServicoDAO osDAO = new OrdemDeServicoDAO();


        private OrdemDeServico transformOrdemDeServicoViewInOrdemDeServico(OrdemDeServicoView osView)
        {
            OrdemDeServico os = new OrdemDeServico(osView.Id, osView.Responsavel, osView.Setor, osView.Cliente, osView.Etapas, osView.Status, osView.DataConclusao, osView.DataEntrega);

            return os;
        }

        public OrdemDeServicoView transformOrdemDeServicoInOrdemDeServicoView(OrdemDeServico os)
        {
            OrdemDeServicoView osView = new OrdemDeServicoView(os);
            return osView;
        }

        public OrdemDeServicoView getOrdemDeServicoViewByOrdemDeServicoId(int id)
        {
            return transformOrdemDeServicoInOrdemDeServicoView(findById(id));
        }

        public OrdemDeServico findById(int id)
        {
            return osDAO.findById(id);
        }
        public OrdemDeServicoView findViewById(int id)
        {
            return transformOrdemDeServicoInOrdemDeServicoView(osDAO.findById(id));
        }
        public void saveOrdemDeServico(OrdemDeServicoView sView)
        {
            OrdemDeServico os = transformOrdemDeServicoViewInOrdemDeServico(sView);
            osDAO.saveOrdemDeServico(os);
        }

        public void atualizaOrdemDeServico(OrdemDeServicoView sView)
        {
            osDAO.updateOrdemDeServico(transformOrdemDeServicoViewInOrdemDeServico(sView));
        }

        public void deleteOrdemDeServico(int id)
        {
            osDAO.deleteOrdemDeServico(id);
        }
    }
}