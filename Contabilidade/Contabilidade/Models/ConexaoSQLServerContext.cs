using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace Contabilidade.Models
{
    public class ConexaoSQLServerContext : DbContext
    {
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Etapa> Etapa { get; set; }
        public DbSet<Obrigacao> Obrigacao { get; set; }
        public DbSet<OrdemDeServico> OrdemDeServico { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Setor> Setor { get;set; }

        
        //public ConexaoSQLServerContext() : base("DBTESTE")
        //{
        //}
    }
}