using Contabilidade.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Contabilidade.Models
{
    [Table("OrdemDeServico")]
    public class OrdemDeServico
    {
        public int Id { get; set; }
        public Usuario Responsavel { get; set; }
        public Setor Setor { get; set; }
        public Cliente Cliente { get; set; }
        public ICollection<Etapa> Etapas { get; set; }
        public bool Status { get; set; } //false para aberta true para concluida
        public DateTime? DataConclusao { get; set; }
        public DateTime? DataEntrega { get; set; }

        public OrdemDeServico(int id, Usuario responsavel, Setor setor, Cliente cliente, ICollection<Etapa> etapas, bool status, DateTime? dataConclusao, DateTime? dataEntrega)
        {
            this.Id = id;
            this.Responsavel = responsavel;
            this.Setor = setor;
            this.Etapas = etapas;
            this.Status = status;
            this.DataConclusao = dataConclusao;
            this.DataEntrega = dataEntrega;
        }

        public OrdemDeServico()
        {
        }


    }
}