using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Contabilidade.Models
{
    [Table("OrdemDeServico")]
    public class OrdemDeServico
    {
        public int Id { get; set; }
        public Usuario Responsavel { get; set; }
        public Setor Setor { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<Etapa> Etapas { get; set; }
        public string status { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataConclusao { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataEntrega { get; set; }
    }
}