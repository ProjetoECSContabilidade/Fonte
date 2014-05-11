using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Contabilidade.Models
{
    [Table("Obrigacao")]
    public class Obrigacao
    {
        public int Id { get; set; }
        public string Descricao { get; set; }
        [Range(1, 31, ErrorMessage = "Informe um dia válido")]
        public int DiaEntrega { get; set; }
        [DataType(DataType.Date)]
        public DateTime DataValidade { get; set; }
        public Setor setor { get; set; }
    }
}