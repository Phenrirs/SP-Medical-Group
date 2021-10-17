using senai_SPMedcialGroup_webApi.Contexts;
using senai_SPMedcialGroup_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SPMedcialGroup_webApi.Repositories
{
    public class PacienteRepository
    {
        SPMedicalGroup ctx = new SPMedicalGroup();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPaciente"></param>
        /// <param name="pacienAtualizada"></param>
        public void Atualizar(int idPaciente, Paciente pacienAtualizada)
        {
            Paciente pacienBuscado = BuscarPorId(idPaciente);

            if (pacienBuscado != null)
            {
                pacienBuscado.Idusuario = pacienAtualizada.Idusuario;
                pacienBuscado.NomePaci = pacienAtualizada.NomePaci;
                pacienBuscado.Email = pacienAtualizada.Email;
                pacienBuscado.DataNasc = pacienAtualizada.DataNasc;
                pacienBuscado.Telcontato = pacienAtualizada.Telcontato;
                pacienBuscado.Rg = pacienAtualizada.Rg;
                pacienBuscado.Cpf = pacienAtualizada.Cpf;
                pacienBuscado.Endereco = pacienAtualizada.Endereco;

                ctx.Pacientes.Update(pacienBuscado);

                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPaciente"></param>
        /// <returns></returns>
        public Paciente BuscarPorId(int idPaciente)
        {
            return ctx.Pacientes.FirstOrDefault(P => P.IdPaciente == idPaciente);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="novoPaciente"></param>
        public void Cadastrar(Paciente novoPaciente)
        {
            ctx.Pacientes.Add(novoPaciente);

            ctx.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPaciente"></param>
        public void Deletar(int idPaciente)
        {

            Paciente pacienDeletado = BuscarPorId(idPaciente);

            if (pacienDeletado != null)
            {
                ctx.Pacientes.Remove(pacienDeletado);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Paciente> ListarTodos()
        {
            return ctx.Pacientes.ToList();
        }
    }
}
