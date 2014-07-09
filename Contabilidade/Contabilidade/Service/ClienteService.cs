using Contabilidade.DAO;
using Contabilidade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contabilidade.ViewModel;
using System.Web.Mvc;
using System.Collections;

namespace Contabilidade.Service
{
    /* SERVICE
      A função das classes Service é armazenar metodos que podem ser reaproveitados pelo controller ou por outras classes em geral,
      Geralmente mediando a chamada de metodos entre controller e DAO.
      Normalmente contem a parte mais tecnica do projeto, como manipulação de objetos, listas, classes etc..
    */

    public class ClienteService
    {
        private ClienteDAO clienteDAO = new ClienteDAO();
        private ObrigacaoService obgService = new ObrigacaoService();
        private UsuarioService usuarioService = new UsuarioService();
        private ConexaoSQLServerContext db = new ConexaoSQLServerContext();


        public ClienteView inicializaClienteView(ClienteView cv){
            List<IEnumerable<SelectListItem>> obSeparadasPorSetorList = obgService.transformObrigacoesSeparadasPorSetorEmSelectListItem(obgService.getObrigacoesSeparadasPorSetor(null));

            cv.AllObrigacoesFiscais = obSeparadasPorSetorList[0];
            cv.AllObrigacoesContabeis = obSeparadasPorSetorList[1];
            cv.AllObrigacoesRH = obSeparadasPorSetorList[2];
            cv.AllUsuarios = usuarioService.getAllUsuariosAsList();
            return cv;
        }

        public Cliente findById(int id)
        {
            return clienteDAO.findById(id);
        }
        public ClienteView findViewById(int id)
        {
            return transformClienteInClienteView(findById(id));
        }

        public List<ClienteView> getAllClientes()
        {
            List<ClienteView> listaDeClienteView = new List<ClienteView>();
            List<Cliente> listaDeClientes = clienteDAO.getAllClientes();

            foreach (Cliente cliente in listaDeClientes)
            {
                listaDeClienteView.Add(transformClienteInClienteView(cliente));
            }

            return listaDeClienteView;
        }
        private Cliente transformClienteViewInCliente(ClienteView cView)
        {
            Cliente cliente = new Cliente();
        
            cliente.Municipio = cView.Municipio;
            cliente.ISSRetencao = cView.ISSRetencao;
            cliente.Natureza = cView.Natureza;

            //pega as obrigacoes pelos ids que estao nos arrays de string de cView
            ArrayList ids = new ArrayList();
            foreach(string id in cView.SelectedObrigadoesFiscais){
                ids.Add(Convert.ToInt32(id));
            }
            foreach(string id in cView.SelectedObrigadoesContabeis){
                ids.Add(Convert.ToInt32(id));
            }
            foreach(string id in cView.SelectedObrigadoesRH){
                ids.Add(Convert.ToInt32(id));
            }

            ICollection<Obrigacao> obrigacoesList = obgService.getObrigacoesById(ids);

            //para nao salvar as obrigacoes, e sim referencias as que ja existem no banco.
            cliente.Obrigacoes = obrigacoesList.Select(obrigacao => db.Obrigacao.FirstOrDefault(x=>x.Id == obrigacao.Id)).ToList();

            cliente.RazaoSocial = cView.RazaoSocial;
            cliente.RegimeApuracao = cView.RegimeApuracao;
            cliente.ResponsavelContabil = usuarioService.findById(cView.ResponsavelContabilId);
            cliente.ResponsavelFiscal = usuarioService.findById(cView.ResponsavelFiscalId);
            cliente.ResponsavelRH = usuarioService.findById(cView.ResponsavelRHId);
            cliente.SetorEconomico = cView.SetorEconomico;
            cliente.AtividadeEconomica = cView.AtividadeEconomica;
            cliente.Ativo = cView.Ativo;
            cliente.Cnpj = cView.Cnpj;
            cliente.Estado = cView.Estado;

            return cliente;
        }

        public ClienteView transformClienteInClienteView(Cliente cliente)
        {
            ClienteView cView = new ClienteView(cliente);
            cView.ResponsavelRHId = cView.ResponsavelRH.Id;
            cView.ResponsavelFiscalId = cView.ResponsavelFiscal.Id;
            cView.ResponsavelContabilId = cView.ResponsavelContabil.Id;

            List<List<Obrigacao>> obSeparadasPorSetorList = obgService.getObrigacoesSeparadasPorSetor(cliente.Obrigacoes.Cast<Obrigacao>().ToList());
            if (obSeparadasPorSetorList[0].Count > 0)
            {
                var fiscalSelected = new List<string>();
                foreach (Obrigacao ob in obSeparadasPorSetorList[0])
                {
                    fiscalSelected.Add(ob.Id.ToString());
                }
                cView.SelectedObrigadoesFiscais = fiscalSelected.ToArray();
            }
            if (obSeparadasPorSetorList[1].Count > 0)
            {
                var contabilSelected = new List<string>();
                foreach (Obrigacao ob in obSeparadasPorSetorList[1])
                {
                    contabilSelected.Add(ob.Id.ToString());
                }
                cView.SelectedObrigadoesContabeis = contabilSelected.ToArray();
            }
            if (obSeparadasPorSetorList[2].Count > 0)
            {
                var rhSelected = new List<string>();
                foreach (Obrigacao ob in obSeparadasPorSetorList[2])
                {
                    rhSelected.Add(ob.Id.ToString());
                }
                cView.SelectedObrigadoesRH = rhSelected.ToArray();
            }

            return inicializaClienteView(cView);
        }

        public ClienteView getClienteViewByClienteId(int id)
        {
            return transformClienteInClienteView(findById(id));
        }

        public void saveCliente(ClienteView cView)
        {
            Cliente cliente = transformClienteViewInCliente(cView);
            clienteDAO.saveCliente(cliente);
        }

        public void atualizaCliente(ClienteView cView)
        {
            clienteDAO.updateCliente(transformClienteViewInCliente(cView));
        }

        public void deleteCliente(int id)
        {
            clienteDAO.deleteCliente(id);
        }
		
    }
}