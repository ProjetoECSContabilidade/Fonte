using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        
        public int SetorId { get; set; }

        [Required]
        public string Login { get; set; }
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        [DefaultValue(true)]
        public bool Ativo { get; set; }

        //Chave Estrangeira
        public virtual Cliente Cliente { get; set; }



        public Usuario()
        {
            Ativo = true;
        }

        public Usuario(int id, string nome, string email, string cargo, int setorId, string login, string senha, bool ativo)
        {
            this.Id = id;
            this.Nome = nome;
            this.Email = email;
            this.Cargo = cargo;
            this.SetorId = setorId;
            this.Login = login;
            this.Senha = senha;
            this.Ativo = ativo;
        }
    }

}