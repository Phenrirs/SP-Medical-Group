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
    public class PacientesController : ControllerBase
    {
        private IPacienteRepository _pacienteRepository { get; set; }

        public PacientesController()
        {
            _pacienteRepository = new PacienteRepository();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_pacienteRepository.ListarTodos());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPaciente"></param>
        /// <returns></returns>
        [HttpGet("{idPaciente}")]
        public IActionResult BuscarPorId(int idPaciente)
        {
            return Ok(_pacienteRepository.BuscarPorId(idPaciente));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="novoPaciente"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Paciente novoPaciente)
        {
            _pacienteRepository.Cadastrar(novoPaciente);
            return StatusCode(201);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPaciente"></param>
        /// <param name="pacienAtualizado"></param>
        /// <returns></returns>
        [HttpPut("{idPaciente}")]
        public IActionResult AtualizarPaci(int idPaciente, Paciente pacienAtualizado)
        {
            _pacienteRepository.Atualizar(idPaciente, pacienAtualizado);

            return StatusCode(204);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idPaciente"></param>
        /// <returns></returns>
        [HttpDelete("{idPaciente}")]
        public IActionResult Deletar(int idPaciente)
        {
            _pacienteRepository.Deletar(idPaciente);
            return StatusCode(204);
        }
    }
}
