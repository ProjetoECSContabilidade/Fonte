using Contabilidade.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contabilidade.ViewModel
{
    [Table("Obrigacao")]
    public class ObrigacaoView
    {
        public int Id { get; set; }

        [Required]
        [MinLength(5, ErrorMessage = "O tamanho mínimo da Descrição são 5 caracteres.")]
        [StringLength(500, ErrorMessage = "O tamanho máximo são 500 caracteres.")]
        public string Descricao { get; set; }

        [Range(1, 31, ErrorMessage = "Informe um dia válido"), Required]
        public int DiaEntrega { get; set; }

        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}", ApplyFormatInEditMode = true)]
        public DateTime DataValidade { get; set; }

        [Required]
        public int SetorId { get; set; }

        //campos não salvos no BD

        [NotMapped]
        public Setor Setor { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> SetorList { get; set; }

        public ObrigacaoView(Obrigacao o)
        {
            this.Id = o.Id;
            this.Descricao = o.Descricao;
            this.DiaEntrega = o.DiaEntrega;
            this.DataValidade = o.DataValidade;
            this.SetorId = o.SetorId;
        }
        public ObrigacaoView()
        {

        }
    }
}