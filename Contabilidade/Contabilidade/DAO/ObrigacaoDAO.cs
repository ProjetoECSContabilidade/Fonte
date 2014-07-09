using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contabilidade.Models;
using Contabilidade.DAO;
using Contabilidade.ViewModel;
using Contabilidade.Service;
using System.Data;
using System.Collections;
using System.Data.Entity;

namespace Contabilidade.DAO
{
    /* DAO
      A Função das classes DAO é armazenar as logicas de acesso ao banco de dados,
      como consultas e scripts sql e logica de persistencia de classes(model).
      Os metodos do DAO normalmente são acessados via classe Service.
   */
    public class ObrigacaoDAO
    {
        private ConexaoSQLServerContext db = new ConexaoSQLServerContext();
        private SetorService setorService = new SetorService();

        public void saveObrigacao(Obrigacao obrigacao)
        {
            db.Obrigacao.Add(obrigacao);
            db.SaveChanges();
        }

        public Obrigacao findById(int id)
        {
            return db.Obrigacao.Find(id);
        }   

        public void updateObrigacao(Obrigacao obrigacao)
        {
            db.Entry(obrigacao).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void deleteObrigacao(int id)
        {
            db.Obrigacao.Remove(findById(id));
            db.SaveChanges();
        }

        public List<Obrigacao> getAllObrigacoes()
        {
            return db.Obrigacao.ToList();
        }

        public List<Obrigacao> selectObrigacoesPorFiltro(string filtroDesc, string filtroSetor, int? filtroDia)
        {
            var query = from o in db.Obrigacao
                        select o;

            int setorId=0;

            if (!String.IsNullOrEmpty(filtroSetor)){
                 setorId = setorService.getSetorIdBySetorDesc(filtroSetor);
            }

            if (!String.IsNullOrEmpty(filtroDesc)){
                query = query.Where(o => o.Descricao.Contains(filtroDesc));
            }
            if (setorId != null && setorId != 0){
                query = query.Where(s => s.SetorId == setorId);
            }
            if (filtroDia != null && filtroDia != 0){
                query = query.Where(s => s.DiaEntrega == filtroDia);
            }

            query.Select(o => new Obrigacao
            {   
                Id = o.Id,
                Descricao = o.Descricao,
                DiaEntrega = o.DiaEntrega,
                DataValidade = o.DataValidade,
                SetorId = o.SetorId
            });

            return query.ToList();
        }

        public ICollection<Obrigacao> findObrigacoesById(ArrayList ids)
        {
            //var query = db.Obrigacao.Where(o => ids.Contains(o.Id.ToString()));
            var query = from o in db.Obrigacao.AsEnumerable()
                              where ids.Contains(o.Id)
                              select new Obrigacao
                                {   
                                    Id = o.Id,
                                    Descricao = o.Descricao,
                                    DiaEntrega = o.DiaEntrega,
                                    DataValidade = o.DataValidade,
                                    SetorId = o.SetorId
                                };
            return query.ToList();
        }

    }
}