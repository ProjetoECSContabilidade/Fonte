using Contabilidade.DAO;
using Contabilidade.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Contabilidade.ViewModel;

namespace Contabilidade.Service
{
    public class UsuarioService
    {
        private UsuarioDAO usuarioDAO = new UsuarioDAO();
        private SetorService setorService = new SetorService();

        public List<UsuarioView> getAllUsuarios()
        {
            List<UsuarioView> listaDeUsuarioView = new List<UsuarioView>();
            List<Usuario> listaDeUsuario = usuarioDAO.getAllUsuarios();
            
            foreach (Usuario usu in listaDeUsuario)
            {
                listaDeUsuarioView.Add(transformUsuarioInUsuarioView(usu));
            }

            return listaDeUsuarioView;
        }

        private Usuario transformUsuarioViewInUsuario(UsuarioView uView){
            Usuario usuario = new Usuario(uView.Id,
                uView.Nome,
                uView.Email,
                uView.Cargo,
                uView.SetorId,
                uView.Login,
                uView.Senha,
                uView.Ativo);

            return usuario;
        }

        public UsuarioView transformUsuarioInUsuarioView(Usuario usuario)
        {
            UsuarioView usuView = new UsuarioView(usuario);
            usuView.SetorList = setorService.getAllSetores();
            usuView.Setor = setorService.findById(usuario.SetorId);

            return usuView;
        }

        public Usuario findById(int id)
        {
            return usuarioDAO.findById(id);
        }
        
        public UsuarioView getUsuarioViewByUsuarioId(int id)
        {
            return transformUsuarioInUsuarioView(findById(id));
        }

        public void saveUsuario(UsuarioView usuarioView)
        {
            Usuario usuario = transformUsuarioViewInUsuario(usuarioView);
            usuarioDAO.saveUsuario(usuario);
        }

        public void atualizaUsuario(UsuarioView usuarioView)
        {
            usuarioDAO.atualizaUsuario(transformUsuarioViewInUsuario(usuarioView));
        }

        public void deleteUsuario(int id)
        {
            usuarioDAO.deleteUsuario(id);
        }

    }
}