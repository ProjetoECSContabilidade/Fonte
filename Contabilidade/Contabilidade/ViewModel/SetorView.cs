﻿using Contabilidade.Models;
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
    
    public class SetorView
    {
        [Key]
        public int Id { get; set; }
        [Required, MaxLength(30), MinLength(3)]
        public string Descricao { get; set; }


        public SetorView(Setor s)
        {
            this.Id = s.Id;
            this.Descricao = s.Descricao;
        }
        public SetorView()
        {

        }
    }
}