using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Contabilidade.Models
{
    [Table("Etapa")]
    public class Etapa
    {
        public int Id { get; set; }
        [NotMapped]
        public Obrigacao Obrigacao { get; set; }
        public DateTime? DataEntrega { get; set; }
        public int Status { get; set; } //1-concluida 0-aberta
        public string Descricao { get; set; }

        public virtual ICollection<OrdemDeServico> ListaDeOS { get; set; }
        //public virtual Obrigacao obrigacao { get; set; }

        public Etapa(Obrigacao obrigacao, DateTime? dataEntrega, int status, string descricao)
        {
            this.Obrigacao = obrigacao;
            this.DataEntrega = dataEntrega;
            this.Status = status;
            this.Descricao = descricao;
        }
        public Etapa()
        {
        }

    }
}