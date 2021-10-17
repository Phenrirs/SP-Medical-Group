using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai_SPMedcialGroup_webApi.Domains;
using senai_SPMedcialGroup_webApi.Interfaces;
using senai_SPMedcialGroup_webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai_SPMedcialGroup_webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SituacaosController : ControllerBase
    {
        private ISituacaoRepository _situacaoRepository { get; set; }

        public SituacaosController()
        {
            _situacaoRepository = new SituacaoRepository();
        }

        /// <summary>
        /// Listar todas as situações
        /// </summary>
        /// <returns>Situações Listadas!</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_situacaoRepository.ListarTodos());
        }

        /// <summary>
        /// Buscar qualquer situação regidtrada através dos IDs!
        /// </summary>
        /// <param name="idSituacao">id da situação que será buscada!</param>
        /// <returns></returns>
        [HttpGet("{idSituacao}")]
        public IActionResult BuscarPorId(int idSituacao)
        {
            return Ok(_situacaoRepository.BuscarPorId(idSituacao));
        }

        /// <summary>
        /// Cadastrar novas situações!
        /// </summary>
        /// <param name="novaSituacao">Objeto da entidade situacao que carrega novas informações!</param>
        /// <returns>Situacao cadastrada!</returns>
        [HttpPost]
        public IActionResult Cadastrar(Situacao novaSituacao)
        {
            _situacaoRepository.Cadastrar(novaSituacao);
            return StatusCode(201);
        }

        /// <summary>
        /// Atualizar situações!
        /// </summary>
        /// <param name="idSituacao">id da situacao qu será atualizada!</param>
        /// <param name="situacaoAtualizada">Objeto entidade situação com novas informações!</param>
        /// <returns>Situação atualizada!</returns>
        [HttpPut("{idSituacao}")]
        public IActionResult AtualizarEspeci(int idSituacao, Situacao situacaoAtualizada)
        {
            _situacaoRepository.Atualizar(idSituacao, situacaoAtualizada);

            return StatusCode(204);
        }

        /// <summary>
        /// Feletar situação especifica!
        /// </summary>
        /// <param name="idSituacao">id da siruação que será deletada!</param>
        /// <returns>Situação deletada!</returns>
        [HttpDelete("{idSituacao}")]
        public IActionResult Deletar(int idSituacao)
        {
            _situacaoRepository.Deletar(idSituacao);
            return StatusCode(204);
        }

    }
}
