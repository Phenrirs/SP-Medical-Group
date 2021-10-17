using senai_SPMedcialGroup_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SPMedcialGroup_webApi.Interfaces
{
    interface IConsultaRepository
    {
        List<Consultum> ListarTodos();

        Consultum BuscarPorId(int idConsulta);

        void Cadastrar(Consultum novaConsulta);

        void Atualizar(int idConsulta, Consultum consulAtualizada);

        void Deletar(int idConsulta);
    }
}
