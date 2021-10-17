using senai_SPMedcialGroup_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SPMedcialGroup_webApi.Interfaces
{
    interface ITipoUsuarioRepository
    {
        List<TipoUsuario> ListarTodos();

        TipoUsuario BuscarPorId(int idTipoC);

        void Cadastrar(TipoUsuario novoTipoUser);

        void Atualizar(int idTipoUser, TipoUsuario tipoUserAtualizado);

        void Deletar(int idTipoUser);
    }
}
