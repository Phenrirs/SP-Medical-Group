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
    public class ConsultasController : ControllerBase
    {
        private IConsultaRepository _consultaRepository { get; set; }

        public ConsultasController()
        {
            _consultaRepository = new ConsultaRepository();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_consultaRepository.ListarTodos());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idConsulta"></param>
        /// <returns></returns>
        [HttpGet("{idConsulta}")]
        public IActionResult BuscarPorId(int idConsulta)
        {
            return Ok(_consultaRepository.BuscarPorId(idConsulta));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="novaConsutla"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Consultum novaConsutla)
        {
            _consultaRepository.Cadastrar(novaConsutla);
            return StatusCode(201);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idConsulta"></param>
        /// <param name="consultaAtualizada"></param>
        /// <returns></returns>
        [HttpPut("{idConsutla}")]
        public IActionResult AtualizarConsul(int idConsulta, Consultum consultaAtualizada)
        {
            _consultaRepository.Atualizar(idConsulta, consultaAtualizada);

            return StatusCode(204);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idConsulta"></param>
        /// <returns></returns>
        [HttpDelete("{idConsulta}")]
        public IActionResult Deletar(int idConsulta)
        {
            _consultaRepository.Deletar(idConsulta);
            return StatusCode(204);
        }
    }
}
