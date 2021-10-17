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
    public class EspecialidadesController : ControllerBase
    {
        private IEspecialidadeRepository _especialidadeRepository { get; set; }

        public EspecialidadesController()
        {
            _especialidadeRepository = new EspecialidadeRepository();
        }

        /// <summary>
        /// Listar todas as especialidades!
        /// </summary>
        /// <returns>Um status code 200 (OK)!</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_especialidadeRepository.ListarTodos());
        }

        /// <summary>
        /// uscar uma especialidade atraavés de um id da mesma!
        /// </summary>
        /// <param name="idEspecialidade">id da especialidade que será buscada</param>
        /// <returns></returns>
        [HttpGet("{idEspecialidade}")]
        public IActionResult BuscarPorId(int idEspecialidade)
        {
            return Ok(_especialidadeRepository.BuscarPorId(idEspecialidade));
        }

        /// <summary>
        /// Cadastrar uma especialida!
        /// </summary>
        /// <param name="novaEspeci">Objeto nova especialidade com novas informações!</param>
        /// <returns>Especialidade cadastrada!</returns>
        [HttpPost]
        public IActionResult Cadastrar(Especialidade novaEspeci)
        {
            _especialidadeRepository.Cadastrar(novaEspeci);
            return StatusCode(201);
        }

        /// <summary>
        /// Atualizar especialidades adastradas!
        /// </summary>
        /// <param name="idEspecialidade">id da especialidade que será atualizada!</param>
        /// <param name="especiAtualizada">Objeto especialidade contendo novas informações!</param>
        /// <returns>Especialidade atualizada!</returns>
        [HttpPut("{idEspecialidade}")]
        public IActionResult AtualizarEspeci(int idEspecialidade, Especialidade especiAtualizada)
        {
            _especialidadeRepository.Atualizar(idEspecialidade, especiAtualizada);

            return StatusCode(204);
        }

        /// <summary>
        /// Deletar especialidade especifica!
        /// </summary>
        /// <param name="idEspecialidade">id da especialidade que será deletada!</param>
        /// <returns>Especialidade deletada!</returns>
        [HttpDelete("{idEspecialidade}")]
        public IActionResult Deletar(int idEspecialidade)
        {
            _especialidadeRepository.Deletar(idEspecialidade);
            return StatusCode(204);
        }
    }
}
