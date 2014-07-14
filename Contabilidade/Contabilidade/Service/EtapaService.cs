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

    public class EtapaService
    {
        private EtapaDAO etapaDAO = new EtapaDAO();
        private ObrigacaoService obrigacaoService = new ObrigacaoService();
        private OrdemDeServicoService osService = new OrdemDeServicoService();

        public List<EtapaView> getEtapasByOSId(int osId)
        {
            List<EtapaView> etapaViewList = new List<EtapaView>();
            OrdemDeServico os = osService.findById(osId);
            ICollection<Etapa> etapaList = os.Etapas;

            foreach (Etapa etapa in etapaList)
            {
                EtapaView etapaView = new EtapaView(etapaDAO.findById(etapa.Id));
                if (os.Id.Equals(1))
                {
                    etapaView.Obrigacao = obrigacaoService.findById(1);
                }
                else if (os.Id.Equals(2))
                {
                    etapaView.Obrigacao = obrigacaoService.findById(13);
                }
                else
                {
                    etapaView.Obrigacao = obrigacaoService.findById(7);
                }
                etapaView.Obrigacao = obrigacaoService.findById(etapa.Id);
                etapaView.StatusTela = etapa.Status.Equals(1) ? 0 :  osService.DefineStatusSemaforoTela((DateTime)etapaView.DataEntrega);
                etapaViewList.Add(etapaView);
            }
            return etapaViewList;
        }

        public EtapaView findViewById(int id)
        {
            EtapaView etapaView =  new EtapaView(etapaDAO.findById(id));
            if (id.Equals(1))
            {
                etapaView.Obrigacao = obrigacaoService.findById(1);
            }
            else if (id.Equals(2))
            {
                etapaView.Obrigacao = obrigacaoService.findById(13);
            }
            else
            {
                etapaView.Obrigacao = obrigacaoService.findById(7);
            }
            return etapaView;
            
        }


    }
}