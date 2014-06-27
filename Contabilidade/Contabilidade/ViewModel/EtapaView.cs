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
        [DataType(DataType.Date), Required]
        public DateTime DataEntrega { get; set; }
        public int Status { get; set; }
        public string Descricao { get; set; }



        //APAGAR
        [NotMapped]
        public String ObrigacaoString { get; set; }
        [NotMapped]
        public String ResponsavelString { get; set; }
        [NotMapped]
        public String StatusString { get; set; }
        [NotMapped]
        public bool Concluido { get; set; }

    }
}