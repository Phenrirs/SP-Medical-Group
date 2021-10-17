using senai_SPMedcialGroup_webApi.Contexts;
using senai_SPMedcialGroup_webApi.Domains;
using senai_SPMedcialGroup_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SPMedcialGroup_webApi.Repositories
{
    public class SituacaoRepository : ISituacaoRepository
    {
        SPMedicalGroup ctx = new SPMedicalGroup();

        /// <summary>
        /// Atualizar situações cadastradas!
        /// </summary>
        /// <param name="idSituacao">Ids das situações que serão atualizadas!</param>
        /// <param name="situacaoAtualizada">Entidade das situações!</param>
        public void Atualizar(int idSituacao, Situacao situacaoAtualizada)
        {
            Situacao situacaoBuscada = BuscarPorId(idSituacao);

            if (situacaoBuscada != null)
            {
                situacaoBuscada.Descricao = situacaoAtualizada.Descricao;

                ctx.Situacaos.Update(situacaoBuscada);

                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Buscar situações através dos ids das mesmas!
        /// </summary>
        /// <param name="idSituacao">id da situação que será buscada!</param>
        /// <returns>Situação buscada!</returns>
        public Situacao BuscarPorId(int idSituacao)
        {
            return ctx.Situacaos.FirstOrDefault(s => s.IdSituacao == idSituacao);
        }

        /// <summary>
        /// Cadastro de situações!
        /// </summary>
        /// <param name="novaSituacao">objeto situação contendo novos valores!</param>
        public void Cadastrar(Situacao novaSituacao)
        {
            ctx.Situacaos.Add(novaSituacao);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deletar situações cadastradas!
        /// </summary>
        /// <param name="idSituacao">id da situação que será deletada!</param>
        public void Deletar(int idSituacao)
        {
            Situacao situacaoDeletada = new Situacao();

            situacaoDeletada = BuscarPorId(idSituacao);

            if (situacaoDeletada != null)
            {
                ctx.Situacaos.Remove(situacaoDeletada);
            }
        }

        /// <summary>
        /// Listar todas as ituações dacastradas!
        /// </summary>
        /// <returns>Situações listadas!</returns>
        public List<Situacao> ListarTodos()
        {
            return ctx.Situacaos.ToList();
        }
    }
}
