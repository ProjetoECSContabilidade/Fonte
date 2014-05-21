using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contabilidade.Models
{
    [Table("Usuario")]
    public class Usuario
    {
        public int Id { get; set; }
       
       [Required(ErrorMessage = "Digite o nome do usuario.")]
        public string Nome { get; set; }

       [DataType(DataType.EmailAddress, ErrorMessage="Informe um e-mail valido.")]
        public String Email { get; set; }

        [Required]
        public String Cargo { get; set; }

        public Setor Setor { get; set; }

        public int SetorId { get; set; }
        [NotMapped]
        public IEnumerable<SelectListItem> SetorList { get; set; }
        
        //public IEnumerable<SelectListItem> Setor { get; set; } 


        [Required]
        public string Login { get; set; }
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        
        public bool Ativo { get; set; }
    }
}