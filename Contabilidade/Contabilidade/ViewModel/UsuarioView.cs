using Contabilidade.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Contabilidade.ViewModel
{
    
    public class UsuarioView
    {
        public int Id { get; set; }
       
       [Required(ErrorMessage = "Digite o nome do usuario.")]
        public string Nome { get; set; }

       [DataType(DataType.EmailAddress, ErrorMessage="Informe um e-mail valido.")]
        public String Email { get; set; }

        [Required]
        public String Cargo { get; set; }
        
        public int SetorId { get; set; }

        [Required]
        public string Login { get; set; }
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [DefaultValue(true)]
        public bool Ativo { get; set; }

        //campos não salvos no BD
                
        public Setor Setor { get; set; }
        public IEnumerable<SelectListItem> SetorList { get; set; }


     
        public UsuarioView()
        {
           Ativo = true;
        }
        public UsuarioView(Usuario u)
        {
            this.Id = u.Id;
            this.Nome = u.Nome;
            this.Email = u.Email;
            this.Cargo = u.Cargo;
            this.SetorId = u.SetorId;
            this.Login = u.Login;
            this.Senha = u.Senha;
            this.Ativo = u.Ativo;
        }
    }
}