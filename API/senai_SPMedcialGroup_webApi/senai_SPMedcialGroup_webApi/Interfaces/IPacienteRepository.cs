using senai_SPMedcialGroup_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SPMedcialGroup_webApi.Interfaces
{
    interface IPacienteRepository
    {
        List<Paciente> ListarTodos();

        Paciente BuscarPorId(int idPaciente);

        void Cadastrar(Paciente novoPaciente);

        void Atualizar(int idPaciente, Paciente pacienAtualizado);

        void Deletar(int idPaciente);
    }
}
