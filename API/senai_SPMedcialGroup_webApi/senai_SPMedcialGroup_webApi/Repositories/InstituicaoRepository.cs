using senai_SPMedcialGroup_webApi.Contexts;
using senai_SPMedcialGroup_webApi.Domains;
using senai_SPMedcialGroup_webApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SPMedcialGroup_webApi.Repositories
{
    public class InstituicaoRepository : IInstituicaoRepository
    {
        SPMedicalGroup ctx = new SPMedicalGroup();

        /// <summary>
        /// Atualizar intituições já cadastradas!
        /// </summary>
        /// <param name="idInstituicao">id da instituição que será atualizada!</param>
        /// <param name="instituicaoAtualizada"></param>
        public void Atualizar(int idInstituicao, Instituicao instituicaoAtualizada)
        {
            Instituicao instituicaoBuscada = BuscarPorId(idInstituicao);

            if (instituicaoBuscada != null)
            {
                #region Constatação importante!
                //Nesse caso o método de atualização pode funcionar para atualizar apenas um campo especifico pois com a verificação dos dados 
                //(No códifo acima "Instituicao instituicaoBuscada = BuscarPorId(idInstituicao);") analiza os dados já existentes para após isso
                //poder executar a atualização!
                #endregion 

                instituicaoBuscada.Cnpj = instituicaoAtualizada.Cnpj;
                instituicaoBuscada.RazaoSocial = instituicaoAtualizada.RazaoSocial;
                instituicaoBuscada.NomeFantasia = instituicaoAtualizada.NomeFantasia;
                instituicaoBuscada.Endereco = instituicaoAtualizada.Endereco;
                instituicaoBuscada.TelContato = instituicaoAtualizada.TelContato;

                ctx.Instituicaos.Update(instituicaoBuscada);

                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Buscar intituições através do id!
        /// </summary>
        /// <param name="idInstituicao">id da instituição que será buscada</param>
        /// <returns>Instituicao buscada!</returns>
        public Instituicao BuscarPorId(int idInstituicao)
        {
            return ctx.Instituicaos.FirstOrDefault(I => I.IdInstituicao == idInstituicao);
        }

        /// <summary>
        /// Cadastrar intituições!
        /// </summary>
        /// <param name="novaInstituicao">Objeto nova instituição com novas informações!</param>
        public void Cadastrar(Instituicao novaInstituicao)
        {
            ctx.Instituicaos.Add(novaInstituicao);

            ctx.SaveChanges();
        }

        /// <summary>
        /// Deletar intituição especifica!
        /// </summary>
        /// <param name="idInstituicao">id da instituição que será deletado!</param>
        public void Deletar(int idInstituicao)
        {
            Instituicao instituicaoDeletado = new Instituicao();

            instituicaoDeletado = BuscarPorId(idInstituicao);

            if (instituicaoDeletado != null)
            {
                ctx.Instituicaos.Remove(instituicaoDeletado);
            }
        }

        /// <summary>
        /// Listar todas as instituições!
        /// </summary>
        /// <returns>Instituições listadas!</returns>
        public List<Instituicao> ListarTodos()
        {
            return ctx.Instituicaos.ToList();
        }
    }
}
