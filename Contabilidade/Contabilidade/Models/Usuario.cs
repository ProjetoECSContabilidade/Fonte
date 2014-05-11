using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Contabilidade.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        public int Id { get; set; }
       [Required]
        public string Nome { get; set; }

        public int Cargo { get; set; }

        public Setor Setor { get; set; }

        public string Login { get; set; }
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        
        public bool Ativo { get; set; }
    }
}