using Contabilidade.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

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
    
    }
}