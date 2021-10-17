using senai_SPMedcialGroup_webApi.Contexts;
using senai_SPMedcialGroup_webApi.Domains;
using senai_SPMedcialGroup_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SPMedcialGroup_webApi.Repositories
{
    public class EspecialidadeRepository : IEspecialidadeRepository
    {
        SPMedicalGroup ctx = new SPMedicalGroup();

        /// <summary>
        /// Atualizar especialidades cadastradas!
        /// </summary>
        /// <param name="idEspecialidade">id da especialidade que será atualizada!</param>
        /// <param name="especiAtualizada">Entidade responsável pelas especialidades registradas!</param>
        public void Atualizar(int idEspecialidade, Especialidade especiAtualizada)
        {
            Especialidade especialidadeBuscada = BuscarPorId(idEspecialidade);

            if (especialidadeBuscada != null)
            {
                especialidadeBuscada.Tema = especiAtualizada.Tema;

                ctx.Especialidades.Update(especialidadeBuscada);

                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Buscar especialidade especifica através do id!
        /// </summary>
        /// <param name="idEspecialidade">id da especialidade que será buscada!</param>
        /// <returns>Especialidade buscada!</returns>
        public Especialidade BuscarPorId(int idEspecialidade)
        {
            return ctx.Especialidades.FirstOrDefault(s => s.IdEspecialidade == idEspecialidade);
        }

        /// <summary>
        /// Cadastrar uma nova especialidade!
        /// </summary>
        /// <param name="novaEspecialidade">Objeto especialidade com novas informações!</param>
        public void Cadastrar(Especialidade novaEspecialidade)
        {
            ctx.Especialidades.Add(novaEspecialidade);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deletar esecialidade especifica!
        /// </summary>
        /// <param name="idEspecialidade">id da especialidade que será deletada!</param>
        public void Deletar(int idEspecialidade)
        {
            Especialidade especiDeletada = new Especialidade();

            especiDeletada = BuscarPorId(idEspecialidade);

            if (especiDeletada != null)
            {
                ctx.Especialidades.Remove(especiDeletada);
            }
        }

        /// <summary>
        /// Listar todas as especialidades!
        /// </summary>
        /// <returns>Especialidades listadas!</returns>
        public List<Especialidade> ListarTodos()
        {
            return ctx.Especialidades.ToList();
        }
    }
}
