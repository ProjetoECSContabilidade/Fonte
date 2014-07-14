using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contabilidade.DAO;
using Contabilidade.Service;
using Contabilidade.Models;
using Contabilidade.ViewModel;
//for quartz
using Quartz;

namespace Contabilidade.Job
{
    public class CronJobOS : IJob
    {
        ClienteService clienteService = new ClienteService();
        ClienteDAO clienteDAO = new ClienteDAO();
        OrdemDeServicoService osService = new OrdemDeServicoService();
        OrdemDeServicoDAO osDAO = new OrdemDeServicoDAO();
        UsuarioService usuarioService = new UsuarioService();
        SetorDAO setorDAO = new SetorDAO();

        static CronJobOS()
        {
        }
        public void Execute(JobExecutionException context)
        {
        }

        public void Execute(IJobExecutionContext context)
        {
        }

        public void Execute()
        {
            List<Cliente> clientesAtivos = clienteDAO.getAtivos();

            foreach (Cliente cliente in clientesAtivos)
            {
                ICollection<Obrigacao> obrigacoes = cliente.Obrigacoes;
                List<OrdemDeServico> ordensDeServico = osDAO.getOSByClienteId(cliente.Id);

                foreach (Obrigacao obrigacao in obrigacoes)
                {
                    bool obrigacaoTemEtapaCriada = false;
                    if(!(obrigacao.DataValidade < DateTime.Now))
                    {
                        //para cada obrigacao que o cliente tiver, devera varrer as OS abertas para este cliente verificando se em alguma OS existe uma Etapa com aquela Obrigacao. 
                        foreach (OrdemDeServico os in ordensDeServico)
                        {
                            ICollection<Etapa> etapas = os.Etapas;
                            foreach (Etapa etapa in etapas)
                            {
                                if (etapa.Obrigacao.Id == obrigacao.Id && etapa.Status.Equals(0))
                                {
                                    obrigacaoTemEtapaCriada = true;
                                }
                            }
                        }
                        if (!obrigacaoTemEtapaCriada)
                        {
                            OrdemDeServico novaOS = new OrdemDeServico();
                            novaOS.DataEntrega = obrigacao.DataValidade;
                            novaOS.Cliente = cliente;
                            novaOS.Responsavel = usuarioService.findById(1);
                            novaOS.Setor = setorDAO.findById(obrigacao.SetorId);
                            novaOS.Status = false; //aberta

                            Etapa novaEtapa = new Etapa(obrigacao, obrigacao.DataValidade, 0, obrigacao.Descricao);

                            ICollection<Etapa> listaEtapas = new List<Etapa>();
                            listaEtapas.Add(novaEtapa);
                            novaOS.Etapas = listaEtapas;

                            osDAO.saveOrdemDeServico(novaOS);
                        }
                    }
                    
                }

            }

        }

    }
}