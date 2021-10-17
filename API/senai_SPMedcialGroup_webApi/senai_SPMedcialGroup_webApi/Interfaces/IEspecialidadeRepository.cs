using senai_SPMedcialGroup_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SPMedcialGroup_webApi.Interfaces
{
    interface IEspecialidadeRepository
    {
        List<Especialidade> ListarTodos();

        Especialidade BuscarPorId(int idEspecialidade);

        void Cadastrar(Especialidade novaEspecialidade);

        void Atualizar(int idEspecialidade, Especialidade especiAtualizada);

        void Deletar(int idEspecialidade);
    }
}
