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
    public class InstituicaosController : ControllerBase
    {
        private IInstituicaoRepository _instituicaoRepository { get; set; }

        public InstituicaosController()
        {
            _instituicaoRepository = new InstituicaoRepository();
        }

        /// <summary>
        /// Listar todas as intituições cadastradas!
        /// </summary>
        /// <returns>Lista de instituições!</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_instituicaoRepository.ListarTodos());
        }

        /// <summary>
        /// Buscar instituições através dos ids!
        /// </summary>
        /// <param name="idInstituicao">id da instituição que será buscada!</param>
        /// <returns>Instituição Buscada!</returns>
        [HttpGet("{idInstituicao}")]
        public IActionResult BuscarPorId(int idInstituicao)
        {
            return Ok(_instituicaoRepository.BuscarPorId(idInstituicao));
        }

        /// <summary>
        /// Cadastrar novas instituições!
        /// </summary>
        /// <param name="novaInstituicao">Objeto entidade Instituição contendo novas informações!</param>
        /// <returns>Instituição cadastrada!</returns>
        [HttpPost]
        public IActionResult Cadastrar(Instituicao novaInstituicao)
        {
            _instituicaoRepository.Cadastrar(novaInstituicao);
            return StatusCode(201);
        }

        /// <summary>
        /// Atualizar instituições já cadastradas!
        /// </summary>
        /// <param name="idInstituicao">id da instituição que será cadastrada!</param>
        /// <param name="intituiAtualizada">Objeto entidade instituição contendo as novas informações!</param>
        /// <returns>Instituição Atualizada!</returns>
        [HttpPut("{idInstituicao}")]
        public IActionResult AtualizarInsti(int idInstituicao, Instituicao intituiAtualizada)
        {
            _instituicaoRepository.Atualizar(idInstituicao, intituiAtualizada);

            return StatusCode(204);
        }

        /// <summary>
        /// Deletar instituições já cadastradas!
        /// </summary>
        /// <param name="idInstituicao">id da instituição que será deletada!</param>
        /// <returns>Instituição que será deletada!</returns>
        [HttpDelete("{idInstituicao}")]
        public IActionResult Deletar(int idInstituicao)
        {
            _instituicaoRepository.Deletar(idInstituicao);
            return StatusCode(204);
        }
    }
}
