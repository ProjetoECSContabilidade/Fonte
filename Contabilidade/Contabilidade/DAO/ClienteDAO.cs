using Contabilidade.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity.Validation;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using System.Data.Objects.DataClasses;
using System.Data.Objects;
using System.Reflection;

namespace Contabilidade.DAO
{
    /* DAO
      A Função das classes DAO é armazenar as logicas de acesso ao banco de dados,
      como consultas e scripts sql e logica de persistencia de classes(model).
      Os metodos do DAO normalmente são acessados via classe Service.
    */
    public class ClienteDAO
    {
        private ConexaoSQLServerContext db = new ConexaoSQLServerContext();

        public Cliente findById(int id)
        {
            Cliente cliente = db.Cliente.Where(x => x.Id == id)
                .Include(x => x.Obrigacoes)
                .Include(x => x.ResponsavelRH)
                .Include(x => x.ResponsavelFiscal)
                .Include(x => x.ResponsavelContabil)
                .First();
            //ou add cliente.Obrigacoes.Select(obrigacao => db.Obrigacao.FirstOrDefault(x => x.Id == obrigacao.Id)).ToList();
            //return db.Cliente.Find(id);
            return cliente;
        }

        public void saveCliente(Cliente cliente)
        {
            try
            {
                /* faz tipo um foreach nas obrigacoes fazendo a referencia com as que existem no banco, 
                 * vinculando os ids na tabela de relacionamento entre as duas classes.
                 * linka os objetos na memoria aos objetos relacionados do banco
                 */
                cliente.Obrigacoes = cliente.Obrigacoes.Select(obrigacao => db.Obrigacao.FirstOrDefault(x => x.Id == obrigacao.Id)).ToList();
                //codigo abaixo relaciona o usuario do banco ao responsavel selecionado.
                cliente.ResponsavelContabil = db.Usuario.Select(usuario => db.Usuario.FirstOrDefault(x => x.Id == cliente.ResponsavelContabil.Id)).FirstOrDefault();
                cliente.ResponsavelFiscal = db.Usuario.Select(usuario => db.Usuario.FirstOrDefault(x => x.Id == cliente.ResponsavelFiscal.Id)).FirstOrDefault();
                cliente.ResponsavelRH = db.Usuario.Select(usuario => db.Usuario.FirstOrDefault(x => x.Id == cliente.ResponsavelRH.Id)).FirstOrDefault();

                db.Cliente.Add(cliente);
                db.SaveChanges();
            }
            catch (DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                        Trace.TraceInformation("Class: {0}, Property: {1}, Error: {2}",
                            validationErrors.Entry.Entity.GetType().FullName,
                            validationError.PropertyName,
                            validationError.ErrorMessage);
                    }
                }

                throw;  // You can also choose to handle the exception here...
            }
        }

        public void updateCliente(Cliente cliente)
        {
            ////get current entry from db (db is context)
            //var clienteDoBD = db.Entry<Models.Cliente>(cliente);

            ////change item state to modified
            //clienteDoBD.State = System.Data.EntityState.Modified;

            ////load existing items for ManyToMany collection
            //clienteDoBD.Collection(c => c.Obrigacoes).Load();

            ////clear Student items          
            //cliente.Obrigacoes.Clear();

            ////add Toner items
            //foreach (var obrigacao in cliente.Obrigacoes)
            //{
            //    var obg = db.Obrigacao.Find(obrigacao.Id);
            //    cliente.Obrigacoes.Add(obg);
            //}

            Cliente clienteSalvar = db.Cliente.Where(x => x.Id == cliente.Id).First();
            clienteSalvar.AtividadeEconomica = cliente.AtividadeEconomica;
            clienteSalvar.Ativo = cliente.Ativo;
            clienteSalvar.Cnpj = cliente.Cnpj;
            clienteSalvar.Estado = cliente.Estado;
            clienteSalvar.ISSRetencao = cliente.ISSRetencao;
            clienteSalvar.Municipio = cliente.Municipio;
            clienteSalvar.Natureza = cliente.Natureza;
            clienteSalvar.RazaoSocial = cliente.RazaoSocial;
            clienteSalvar.RegimeApuracao = cliente.RegimeApuracao;
            clienteSalvar.SetorEconomico = cliente.SetorEconomico;
            clienteSalvar.Obrigacoes =  null;
            //clienteSalvar.Obrigacoes = clienteSalvar.Obrigacoes.Select(obrigacao => db.Obrigacao.FirstOrDefault(x => x.Id == obrigacao.Id)).ToList();
            //clienteSalvar.Obrigacoes.Clear();
            //db.SaveChanges();

            //clienteSalvar.Obrigacoes = cliente.Obrigacoes.Select(obrigacao => db.Obrigacao.FirstOrDefault(x => x.Id == obrigacao.Id)).ToList();
            //codigo abaixo relaciona o usuario do banco ao responsavel selecionado.
            clienteSalvar.ResponsavelContabil = db.Usuario.Select(usuario => db.Usuario.FirstOrDefault(x => x.Id == cliente.ResponsavelContabil.Id)).FirstOrDefault();
            clienteSalvar.ResponsavelFiscal = db.Usuario.Select(usuario => db.Usuario.FirstOrDefault(x => x.Id == cliente.ResponsavelFiscal.Id)).FirstOrDefault();
            clienteSalvar.ResponsavelRH = db.Usuario.Select(usuario => db.Usuario.FirstOrDefault(x => x.Id == cliente.ResponsavelRH.Id)).FirstOrDefault();

            db.SaveChanges();
        }

        public void deleteCliente(int id)
        {
            Cliente clienteExcluir = db.Cliente.Where(x => x.Id == id).First();
            db.Set<Cliente>().Remove(clienteExcluir);
            db.SaveChanges();
        }

        /*
         * Include necessario pois o LazyLoad não traz as informações dos usuarios ou obrigacoes quando carrega o cliente.
         * com o Include traz :)
         */
        public List<Cliente> getAllClientes()
        {
            return db.Cliente
                .Include(x => x.Obrigacoes)
                .Include(x => x.ResponsavelRH)
                .Include(x => x.ResponsavelFiscal)
                .Include(x => x.ResponsavelContabil)
                .ToList();
        }

        public List<Cliente> getAtivos()
        {
            return db.Cliente
                .Where(c => c.Ativo == true)
                .Include(c => c.Obrigacoes)
                .ToList();
        }

        public IEnumerable<SelectListItem> getAllClientesAsList()
        {
            var query = db.Cliente.ToList().Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.RazaoSocial,
            });
            return query.AsEnumerable();
        }
    }
}