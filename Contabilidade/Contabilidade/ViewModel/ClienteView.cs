using Contabilidade.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contabilidade.ViewModel
{

    public class ClienteView
    {
        public int Id { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public string Municipio { get; set; }
        public string Estado { get; set; }
        public string SetorEconomico { get; set; }
        public string Natureza { get; set; }
        public string RegimeApuracao { get; set; }
        public string ISSRetencao { get; set; }
        public string AtividadeEconomica { get; set; }
        public bool Ativo { get; set; }
        public ICollection<Obrigacao> Obrigacoes { get; set; }
        public Usuario ResponsavelFiscal { get; set; }
        public Usuario ResponsavelContabil { get; set; }
        public Usuario ResponsavelRH { get; set; }

        //campos exclusivos da view
        public int ResponsavelFiscalId { get; set; }
        public int ResponsavelContabilId { get; set; }
        public int ResponsavelRHId { get; set; }

        public IEnumerable<SelectListItem> AllObrigacoesFiscais { get; set; }
        public string[] SelectedObrigadoesFiscais { get; set; }
        public IEnumerable<SelectListItem> AllObrigacoesContabeis { get; set; }
        public string[] SelectedObrigadoesContabeis { get; set; }

        public IEnumerable<SelectListItem> AllObrigacoesRH { get; set; }
        public string[] SelectedObrigadoesRH { get; set; }
        public IEnumerable<SelectListItem> AllUsuarios { get; set; }

        public ClienteView(Cliente c)
        {
            this.Id = c.Id;
            this.RazaoSocial = c.RazaoSocial;
            this.Cnpj = c.Cnpj;
            this.Municipio = c.Municipio;   
            this.Estado = c.Estado;   
            this.SetorEconomico = c.SetorEconomico;   
            this.Natureza = c.Natureza;   
            this.RegimeApuracao = c.RegimeApuracao;   
            this.ISSRetencao = c.ISSRetencao;   
            this.AtividadeEconomica = c.AtividadeEconomica;
            this.Ativo = c.Ativo;
            this.Obrigacoes = c.Obrigacoes;
            this.ResponsavelFiscal = c.ResponsavelFiscal;
            this.ResponsavelContabil = c.ResponsavelContabil;
            this.ResponsavelRH = c.ResponsavelRH;
        }
        public ClienteView()
        {
        }
    
    }
}