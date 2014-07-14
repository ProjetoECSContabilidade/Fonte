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
        private UsuarioService usuarioService = new UsuarioService();
        private ClienteService clienteService = new ClienteService();
        private SetorService setorService = new SetorService();


        private OrdemDeServico transformOrdemDeServicoViewInOrdemDeServico(OrdemDeServicoView osView)
        {
            OrdemDeServico os = new OrdemDeServico(osView.Id, osView.Responsavel,
                osView.Setor, osView.Cliente, osView.Etapas,
                osView.Status, osView.DataConclusao, osView.DataEntrega);

            return os;
        }

        public OrdemDeServicoView transformOrdemDeServicoInOrdemDeServicoView(OrdemDeServico os)
        {
            OrdemDeServicoView osView = new OrdemDeServicoView(os);
            DateTime dataEntrega = (DateTime)osView.DataEntrega;
            osView.StatusTela = DefineStatusSemaforoTela(dataEntrega);
            bool temEtapaAtiva = true;

            //valida se as etaptas estao ativas
            foreach (Etapa etapa in osView.Etapas)
            {
                if (etapa.Status.Equals(1))
                {
                    temEtapaAtiva = false;
                }
            }
            if (!temEtapaAtiva)
            {
                osView.StatusTela = 0;
                osView.Status = true;
            }

            return osView;
        }

        public int DefineStatusSemaforoTela(DateTime dataEntrega)
        {
            int statusTela = 0;
            if (dataEntrega < DateTime.Now)
            {
                statusTela = 2;

            }
            else if (dataEntrega > DateTime.Now && dataEntrega.AddDays(7) < DateTime.Now)
            {
                statusTela = 1;
            }
            else
            {
                statusTela = 3;
            }
            return statusTela;
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

        public List<OrdemDeServicoView> getAllOrdensDeServico()
        {
            List<OrdemDeServicoView> listaDeOSView = new List<OrdemDeServicoView>();
            List<OrdemDeServico> listaDeOS = osDAO.getAllOS();

            foreach (OrdemDeServico os in listaDeOS)
            {
                listaDeOSView.Add(transformOrdemDeServicoInOrdemDeServicoView(os));
            }

            return listaDeOSView;
        }
        
        public OrdemDeServicoView inicializaOSView(OrdemDeServicoView osView)
        {
            //osView.AllUsuarios = usuarioService.getAllUsuariosAsList();
            //osView.AllClientes = clienteService.getAllClientesAsList();
            //osView.AllSetores = setorService.getAllSetoresAsList();

            return osView;
        }
    }
}