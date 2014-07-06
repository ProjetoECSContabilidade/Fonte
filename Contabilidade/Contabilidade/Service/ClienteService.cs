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

    public class ClienteService
    {
        private ClienteDAO clienteDAO = new ClienteDAO();
        private ObrigacaoService obgService = new ObrigacaoService();
        private UsuarioService usuarioService = new UsuarioService();


        public ClienteView inicializaClienteView(ClienteView cv){
            List<IEnumerable<SelectListItem>> obSeparadasPorSetorList = obgService.transformObrigacoesSeparadasPorSetorEmSelectListItem(obgService.getObrigacoesSeparadasPorSetor());

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
        private Cliente transformClienteViewInCliente(ClienteView clienteView)
        {
            Cliente cliente = new Cliente();

            return cliente;
        }

        public ClienteView transformClienteInClienteView(Cliente cliente)
        {
            ClienteView cView = new ClienteView(cliente);
            return cView;
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