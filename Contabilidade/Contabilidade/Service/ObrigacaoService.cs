using Contabilidade.DAO;
using Contabilidade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contabilidade.ViewModel;
using System.Web.Mvc;

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

        public List<ObrigacaoView> getAllObrigacoesAsView()
        {
            List<ObrigacaoView> listaDeObrigacaoView = new List<ObrigacaoView>();
            List<Obrigacao> listaDeObrigacao = obrigacaoDAO.getAllObrigacoes();

            foreach (Obrigacao ob in listaDeObrigacao)
            {
                listaDeObrigacaoView.Add(transformObrigacaoInObrigacaoView(ob));
            }

            return listaDeObrigacaoView;
        }

        private Obrigacao transformObrigacaoViewInObrigacao(ObrigacaoView oView)
        {
            Obrigacao obrigacao = new Obrigacao(oView.Id,
                oView.Descricao,
                oView.DiaEntrega,
                oView.DataValidade,
                oView.SetorId);

            return obrigacao;
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
            Obrigacao obrigacao = transformObrigacaoViewInObrigacao(obView);
            obrigacaoDAO.saveObrigacao(obrigacao);
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

        public List<Obrigacao> getAllObrigacoes()
        {
            return obrigacaoDAO.getAllObrigacoes();
        }

        public List<List<Obrigacao>> getObrigacoesSeparadasPorSetor() //@TODO refactor
        {
            List<Obrigacao> todasObrigacoesList = getAllObrigacoes();

            List<Obrigacao> obrigacoesFiscaisList = new List<Obrigacao>();
            List<Obrigacao> obrigacoesContabeisList = new List<Obrigacao>();
            List<Obrigacao> obrigacoesRHList = new List<Obrigacao>();
            
            foreach(Obrigacao obg in todasObrigacoesList){
                Setor setorDaObrigacao = setorService.findById(obg.SetorId);
                //TODO TRANSFORMAR PARA CONSTANTES
                if (setorDaObrigacao.Descricao.Equals("Fiscal"))
                {
                    obrigacoesFiscaisList.Add(obg);
                }
                else if (setorDaObrigacao.Descricao.Equals("Contábil"))
                {
                    obrigacoesContabeisList.Add(obg);
                }
                else if (setorDaObrigacao.Descricao.Equals("Recursos Humanos"))
                {
                    obrigacoesRHList.Add(obg);
                }
            }
            List<List<Obrigacao>> obgSeparadaPorSetorList = new List<List<Obrigacao>>();

            obgSeparadaPorSetorList.Add(obrigacoesFiscaisList);
            obgSeparadaPorSetorList.Add(obrigacoesContabeisList);
            obgSeparadaPorSetorList.Add(obrigacoesRHList);


            return obgSeparadaPorSetorList;
        }

        public List<IEnumerable<SelectListItem>> transformObrigacoesSeparadasPorSetorEmSelectListItem(List<List<Obrigacao>> listaSeparadaPorSetor)
        {
            List<IEnumerable<SelectListItem>> listaReturn = new List<IEnumerable<SelectListItem>>();
            for(int i=0; i<=2;i++){ // 0- fiscal 1-contabil 2-rh
                List<Obrigacao> lista = listaSeparadaPorSetor[i];
                List<SelectListItem> allObrigacoes = new List<SelectListItem>();
                foreach(Obrigacao ob in lista){
                    allObrigacoes.Add(new SelectListItem { Value = ob.Id.ToString(), Text = ob.Descricao });
                }
                listaReturn.Add(allObrigacoes);
            }
            return listaReturn;
        }

    }
}