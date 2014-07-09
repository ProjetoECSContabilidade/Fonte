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
                //para o usuario nao precisou por é 1 pra n (one to many)
                //cliente.ResponsavelContabil = db.Usuario.Select(usuario => db.Usuario.FirstOrDefault(x => x.Id == cliente.ResponsavelContabil.Id)).FirstOrDefault();

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
            Cliente clienteSalvar = db.Cliente.Where(x => x.Id == cliente.Id).First();
            clienteSalvar.Obrigacoes = cliente.Obrigacoes.Select(obrigacao => db.Obrigacao.FirstOrDefault(x => x.Id == obrigacao.Id)).ToList();

            db.Entry(clienteSalvar).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void deleteCliente(int id)
        {
            Cliente clienteExcluir = db.Cliente.Where(x => x.Id == id).First();
            db.Set<Cliente>().Remove(clienteExcluir);

            //db.Cliente.Remove(findById(id));
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
    }
}