using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Contabilidade.Models
{
    [Table("Setor")]
    public class Setor
    {
        public int Id { get; set; }
       [Required, MaxLength (30) , MinLength (3) ]
        public string Descricao { get; set; }

    }
}