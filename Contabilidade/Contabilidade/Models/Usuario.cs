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
       
       [Required(ErrorMessage = "Digite o nome do usuario.")]
        public string Nome { get; set; }

       [DataType(DataType.EmailAddress)]
        public String Email { get; set; }
        [Required]
        public String Cargo { get; set; }
        
        public Setor Setor { get; set; }
        [Required]
        public string Login { get; set; }
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        
        public bool Ativo { get; set; }
    }
}