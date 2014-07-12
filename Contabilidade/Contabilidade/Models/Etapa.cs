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
        public int ObrigacaoId { get; set; }
        public Obrigacao Obrigacao { get; set; }

        [DataType(DataType.Date), Required]
        public DateTime DataEntrega { get; set; }
        public int Status { get; set; }
        public string Descricao { get; set; }

        public virtual ICollection<OrdemDeServico> ListaDeOS { get; set; }

    }
}