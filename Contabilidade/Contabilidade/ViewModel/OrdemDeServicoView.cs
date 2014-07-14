using Contabilidade.Models;
using Contabilidade.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contabilidade.ViewModel
{
    public class OrdemDeServicoView
    {
        public int Id { get; set; }
        public Usuario Responsavel { get; set; }
        public Setor Setor { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<Etapa> Etapas { get; set; }
        public bool Status { get; set; } //false para aberta true para concluida
        [DataType(DataType.Date)]

        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DataConclusao { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DataEntrega { get; set; }
        

        //campos especificos da view
        public int ResponsavelId { get; set; }
        public int ClienteId { get; set; }

        public IEnumerable<SelectListItem> AllUsuarios { get; set; }
        public IEnumerable<SelectListItem> AllClientes { get; set; }
        public IEnumerable<SelectListItem> AllSetores { get; set; }

        //0 - normal(sem cor) 1-vencimento em no max 7 dias (amarelo) 2- vencimento a mais que 7 dias 3-ja esta vencido (vermelho)
        public int StatusTela { get; set; } 


        public OrdemDeServicoView(OrdemDeServico os)
        {
            this.Id = os.Id;
            this.Responsavel = os.Responsavel;
            this.Setor = os.Setor;
            this.Etapas = os.Etapas;
            this.Status = os.Status;
            this.DataConclusao = os.DataConclusao;
            this.DataEntrega = os.DataEntrega;
            this.Cliente = os.Cliente;            
        }
        public OrdemDeServicoView()
        {
        }


    }
}