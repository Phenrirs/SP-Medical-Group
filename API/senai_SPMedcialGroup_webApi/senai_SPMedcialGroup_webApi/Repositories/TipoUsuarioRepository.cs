using senai_SPMedcialGroup_webApi.Contexts;
using senai_SPMedcialGroup_webApi.Domains;
using senai_SPMedcialGroup_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SPMedcialGroup_webApi.Repositories
{
    public class TipoUsuarioRepository : ITipoUsuarioRepository
    {
        SPMedicalGroup ctx = new SPMedicalGroup();

        /// <summary>
        /// Atualizar tipos de usuários já cadastrados!
        /// </summary>
        /// <param name="idTipoUser">id do tipo de usuário que será atualizado</param>
        /// <param name="tipoUserAtualizado">Entidade responsável pelos tipo usuarios registrados!</param>
        public void Atualizar(int idTipoUser, TipoUsuario tipoUserAtualizado)
        {
            TipoUsuario tipoUserBuscado = BuscarPorId(idTipoUser);

            if (tipoUserBuscado != null)
            {
                tipoUserBuscado.NomeTipoUser = tipoUserAtualizado.NomeTipoUser;

                ctx.TipoUsuarios.Update(tipoUserBuscado);

                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Buscar os tipos de usuáros através do id!
        /// </summary>
        /// <param name="idTipoUser">id do usuário que será buscado!</param>
        /// <returns>Usuário buscado!</returns>
        public TipoUsuario BuscarPorId(int idTipoUser)
        {
            return ctx.TipoUsuarios.FirstOrDefault(Tu => Tu.IdTipo == idTipoUser);
        }

        /// <summary>
        /// Cadastrar novos tipos de usuários!
        /// </summary>
        /// <param name="novoTipoUser">Objeto tipo usuários que contém novas informações!</param>
        public void Cadastrar(TipoUsuario novoTipoUser)
        {
            ctx.TipoUsuarios.Add(novoTipoUser);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deletar tipos de usuários já cadastrados!
        /// </summary>
        /// <param name="idTipoUser">id do tipo de usuário que será deletado!</param>
        public void Deletar(int idTipoUser)
        {
            TipoUsuario tipoUserDeletado = new TipoUsuario();

            tipoUserDeletado = BuscarPorId(idTipoUser);

            if (tipoUserDeletado != null)
            {
                ctx.TipoUsuarios.Remove(tipoUserDeletado);
            }
        }

        /// <summary>
        /// Listar todos os Tipos de usuários!
        /// </summary>
        /// <returns>ipos de usuários listados!</returns>
        public List<TipoUsuario> ListarTodos()
        {
            return ctx.TipoUsuarios.ToList();
        }
    }
}
