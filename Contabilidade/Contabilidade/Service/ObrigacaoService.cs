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

    public class ObrigacaoService
    {
        private ObrigacaoDAO obrigacaoDAO = new ObrigacaoDAO();
        private SetorService setorService = new SetorService();

        public List<ObrigacaoView> getAllObrigacoes()
        {
            List<ObrigacaoView> listaDeObrigacaoView = new List<ObrigacaoView>();
            List<Obrigacao> listaDeObrigacao = obrigacaoDAO.getAllObrigacoes();

            foreach (Obrigacao usu in listaDeObrigacao)
            {
                listaDeObrigacaoView.Add(transformObrigacaoInObrigacaoView(usu));
            }

            return listaDeObrigacaoView;
        }

        private Obrigacao transformObrigacaoViewInObrigacao(ObrigacaoView oView)
        {
            Obrigacao usuario = new Obrigacao(oView.Id,
                oView.Descricao,
                oView.DiaEntrega,
                oView.DataValidade,
                oView.SetorId);

            return usuario;
        }

        public ObrigacaoView transformObrigacaoInObrigacaoView(Obrigacao obrigacao)
        {
            ObrigacaoView obView = new ObrigacaoView(obrigacao);
            obView.SetorList = setorService.getAllSetoresAsList();
            obView.Setor = setorService.findById(obrigacao.SetorId);

            return obView;
        }

        public Obrigacao findById(int id)
        {
            return obrigacaoDAO.findById(id);
        }

        public ObrigacaoView getObrigacaoViewByObrigacaoId(int id)
        {
            return transformObrigacaoInObrigacaoView(findById(id));
        }

        public void saveObrigacao(ObrigacaoView obView)
        {
            Obrigacao usuario = transformObrigacaoViewInObrigacao(obView);
            obrigacaoDAO.saveObrigacao(usuario);
        }

        public void atualizaObrigacao(ObrigacaoView obView)
        {
            obrigacaoDAO.updateObrigacao(transformObrigacaoViewInObrigacao(obView));
        }

        public void deleteObrigacao(int id)
        {
            obrigacaoDAO.deleteObrigacao(id);
        }

        public List<ObrigacaoView> searchObrigacaoComFiltro(string filtroDesc, string filtroSetor, int? filtroDia)
        {
            List<ObrigacaoView> listaDeView = new List<ObrigacaoView>();
            foreach (Obrigacao ob in obrigacaoDAO.selectObrigacoesPorFiltro(filtroDesc, filtroSetor, filtroDia))
            {
                listaDeView.Add(transformObrigacaoInObrigacaoView(ob));
            }
            return listaDeView;
        }

    }
}