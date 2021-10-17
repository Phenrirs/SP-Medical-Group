using senai_SPMedcialGroup_webApi.Contexts;
using senai_SPMedcialGroup_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SPMedcialGroup_webApi.Repositories
{
    public class MedicoRepository
    {
        SPMedicalGroup ctx = new SPMedicalGroup();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMedico"></param>
        /// <param name="medicoAtualizado"></param>
        public void Atualizar(int idMedico, Medico medicoAtualizado)
        {
            Medico medicoBuscado = BuscarPorId(idMedico);

            if (medicoBuscado != null)
            {
                medicoBuscado.IdInstituicao = medicoAtualizado.IdInstituicao;
                medicoBuscado.Idusuario = medicoAtualizado.Idusuario;
                medicoBuscado.IdEspecialidade = medicoAtualizado.IdEspecialidade;
                medicoBuscado.Crm = medicoAtualizado.Crm;
                medicoBuscado.Nome = medicoAtualizado.Nome;
                medicoBuscado.Email = medicoAtualizado.Email;

                ctx.Medicos.Update(medicoBuscado);

                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMedico"></param>
        /// <returns></returns>
        public Medico BuscarPorId(int idMedico)
        {
            return ctx.Medicos.FirstOrDefault(M => M.IdMedico == idMedico);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="novoMedico"></param>
        public void Cadastrar(Medico novoMedico)
        {
            ctx.Medicos.Add(novoMedico);

            ctx.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idTipoUser"></param>
        public void Deletar(int idMedico)
        {
            Medico medicoDeletado = BuscarPorId(idMedico);

            if (medicoDeletado != null)
            {
                ctx.Medicos.Remove(medicoDeletado);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Medico> ListarTodos()
        {
            return ctx.Medicos.ToList();
        }
    }
}
