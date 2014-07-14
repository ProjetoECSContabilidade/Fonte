using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Contabilidade.Models
{
    public class Login
    {
        [Display(Prompt = "Login")]
        public string Usuario { get; set; }

        [Display(Prompt = "Senha")]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
    }
}