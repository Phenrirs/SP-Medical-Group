using senai_SPMedcialGroup_webApi.Contexts;
using senai_SPMedcialGroup_webApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SPMedcialGroup_webApi.Repositories
{
    public class ConsultaRepository
    {
        SPMedicalGroup ctx = new SPMedicalGroup();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idConsulta"></param>
        /// <param name="consulAtualizada"></param>
        public void Atualizar(int idConsulta, Consultum consulAtualizada)
        {
            Consultum consulBuscada = BuscarPorId(idConsulta);

            if (consulBuscada != null)
            {
                consulBuscada.IdPaciente = consulAtualizada.IdPaciente;
                consulBuscada.IdMedico = consulAtualizada.IdMedico;
                consulBuscada.IdSituacao = consulAtualizada.IdSituacao;
                consulBuscada.DataConsulta = consulAtualizada.DataConsulta;
                consulBuscada.HorarioEntrada = consulAtualizada.HorarioEntrada;
                consulBuscada.HorarioSaida = consulAtualizada.HorarioSaida;

                ctx.Consulta.Update(consulBuscada);

                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idConsulta"></param>
        /// <returns></returns>
        public Consultum BuscarPorId(int idConsulta)
        {
            return ctx.Consulta.FirstOrDefault(Co => Co.IdConsulta == idConsulta);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="novaConsulta"></param>
        public void Cadastrar(Consultum novaConsulta)
        {
            ctx.Consulta.Add(novaConsulta);

            ctx.SaveChanges();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idConsulta"></param>
        public void Deletar(int idConsulta)
        {
            Consultum consulDeletada = new Consultum();

            consulDeletada = BuscarPorId(idConsulta);

            if (consulDeletada != null)
            {
                ctx.Consulta.Remove(consulDeletada);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<Consultum> ListarTodos()
        {
            return ctx.Consulta.ToList();
        }
    }
}
