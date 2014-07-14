using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Contabilidade.Models
{
    [Table("Cliente")]
    public class Cliente
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

        //ChaveEstrangeira
        public virtual ICollection<Usuario> Usuarios { get; set; }
        public virtual ICollection<OrdemDeServico> OrdensDeServico { get; set; }

        public Cliente(int id, string razaoSocial, string cnpj, string municipio, string estado, string setorEconomico, 
            string natureza, string regimaApuracao, string issRetencao, string atividadeEconomica, bool ativo, ICollection<Obrigacao> obrigacoes, 
            Usuario responsavelFiscal, Usuario responsavelContabil, Usuario responseRH)
        {
            this.Id = id;
            this.RazaoSocial = razaoSocial;
            this.Cnpj = cnpj;
            this.Municipio = municipio;
            this.Estado = estado;
            this.SetorEconomico = setorEconomico;
            this.Natureza = natureza;
            this.RegimeApuracao = regimaApuracao;
            this.ISSRetencao = issRetencao;
            this.AtividadeEconomica = atividadeEconomica;
            this.Ativo = ativo;
            this.Obrigacoes = obrigacoes;
            this.ResponsavelFiscal = responsavelFiscal;
            this.ResponsavelContabil = responsavelContabil;
            this.ResponsavelRH = ResponsavelRH;
        }

        public Cliente()
        {
        }
    
    }
}