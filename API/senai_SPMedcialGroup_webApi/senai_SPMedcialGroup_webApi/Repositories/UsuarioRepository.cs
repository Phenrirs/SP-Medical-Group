using senai_SPMedcialGroup_webApi.Contexts;
using senai_SPMedcialGroup_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SPMedcialGroup_webApi.Repositories
{
    public class UsuarioRepository
    {
        SPMedicalGroup ctx = new SPMedicalGroup();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <param name="usuarioAtualizado"></param>
        public void Atualizar(int idUsuario, Usuario usuarioAtualizado)
        {
            Usuario usuarioBuscado = BuscarPorId(idUsuario);

            if (usuarioBuscado != null)
            {
                usuarioBuscado.IdTipo = usuarioAtualizado.IdTipo;

                ctx.Usuarios.Update(usuarioBuscado);

                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        /// <returns></returns>
        public Usuario BuscarPorId(int idUsuario)
        {
            return ctx.Usuarios.FirstOrDefault(u => u.IdUsuario == idUsuario);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="novoUsuario"></param>
        public void Cadastrar(Usuario novoUsuario)
        {
            ctx.Usuarios.Add(novoUsuario);

            ctx.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idUsuario"></param>
        public void Deletar(int idUsuario)
        {
            Usuario usuarioDeletado = BuscarPorId(idUsuario);

            if (usuarioDeletado != null)
            {
                ctx.Usuarios.Remove(usuarioDeletado);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Usuario> ListarTodos()
        {
            return ctx.Usuarios.ToList();
        }
    }
}
