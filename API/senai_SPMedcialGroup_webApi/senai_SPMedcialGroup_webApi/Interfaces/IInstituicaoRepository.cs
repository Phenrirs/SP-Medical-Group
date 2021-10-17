using senai_SPMedcialGroup_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SPMedcialGroup_webApi.Interfaces
{
    interface IInstituicaoRepository
    {
        List<Instituicao> ListarTodos();

        Instituicao BuscarPorId(int idInstituicao);

        void Cadastrar(Instituicao novaInstituicao);

        void Atualizar(int idInstituicao, Instituicao instituicaoAtualizada);

        void Deletar(int idInstituicao);
    }
}
