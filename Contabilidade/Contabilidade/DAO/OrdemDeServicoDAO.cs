using Contabilidade.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Contabilidade.DAO
{
    /* DAO
      A Função das classes DAO é armazenar as logicas de acesso ao banco de dados,
      como consultas e scripts sql e logica de persistencia de classes(model).
      Os metodos do DAO normalmente são acessados via classe Service.
    */
    public class OrdemDeServicoDAO
    {
        private ConexaoSQLServerContext db = new ConexaoSQLServerContext();

        public OrdemDeServico findById(int id)
        {
            return db.OrdemDeServico
                .Where(os => os.Id == id)
                .Include(x => x.Responsavel)
                .Include(x => x.Setor)
                .Include(x => x.Cliente)
                .Include(x => x.Etapas)
                .FirstOrDefault();
        }

        public void saveOrdemDeServico(OrdemDeServico os)
        {
            //linka registro do banco.
            os.Setor = db.Setor.Select(setor => db.Setor.FirstOrDefault(x => x.Id == os.Setor.Id)).FirstOrDefault();
            os.Cliente = db.Cliente.Select(cliente => db.Cliente.FirstOrDefault(x => x.Id == os.Cliente.Id)).FirstOrDefault();
            os.Responsavel = db.Usuario.Select(resp => db.Usuario.FirstOrDefault(x => x.Id == os.Responsavel.Id)).FirstOrDefault();

            db.OrdemDeServico.Add(os);
            db.SaveChanges();
        }

        

        public void updateOrdemDeServico(OrdemDeServico os)
        {
            db.Entry(os).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void deleteOrdemDeServico(int id)
        {
            db.OrdemDeServico.Remove(findById(id));
            db.SaveChanges();
        }

        public List<OrdemDeServico> getAllOS()
        {
            return db.OrdemDeServico
                .Include(x => x.Responsavel)
                .Include(x => x.Setor)
                .Include(x => x.Cliente)
                .Include(x => x.Etapas)
                .ToList();
        }

        public List<OrdemDeServico> getOSByClienteId(int id)
        {
            return db.OrdemDeServico
                .Where(os => os.Cliente.Id == id)
                .Include(x => x.Responsavel)
                .Include(x => x.Setor)
                .Include(x => x.Cliente)
                .Include(x => x.Etapas)
                .ToList();
        }

    }
}