using Contabilidade.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Contabilidade.ViewModel
{   
    public class EtapaView
    {
        public int Id { get; set; }
        [NotMapped]
        public int ObrigacaoId { get; set; }
        public Obrigacao Obrigacao { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime? DataEntrega { get; set; }
        public int Status { get; set; }
        public string Descricao { get; set; }

        public virtual int StatusTela { get; set; }

        public EtapaView(Etapa etapa)
        {
            this.Id = etapa.Id;
            this.Obrigacao = etapa.Obrigacao;
            this.DataEntrega = etapa.DataEntrega;
            this.Status = etapa.Status;
            this.Descricao = etapa.Descricao;
        }
    }
}