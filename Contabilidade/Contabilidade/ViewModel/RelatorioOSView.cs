using Contabilidade.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Contabilidade.ViewModel
{
    public class RelatorioOSView
    {
        [DataType(DataType.Date)]
        public DateTime? DataInicio { get; set; }
        [DataType(DataType.Date)]
        public DateTime? DataFim { get; set; }

        public Setor Setor { get; set; }

        public Usuario Usuario { get; set; }
        public Cliente Cliente { get; set; }
        public String Status { get; set; }

        public bool Abertas { get; set; }
        public bool Fechadas { get; set; }
        public bool Ambas { get; set; }
    }
}