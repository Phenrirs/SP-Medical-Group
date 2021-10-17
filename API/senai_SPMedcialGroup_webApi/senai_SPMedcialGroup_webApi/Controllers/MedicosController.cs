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
    public class MedicosController : ControllerBase
    {
        private IMedicoRepository _medicoRepository { get; set; }

        public MedicosController()
        {
            _medicoRepository = new MedicoRepository();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_medicoRepository.ListarTodos());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMedico"></param>
        /// <returns></returns>
        [HttpGet("{idMedico}")]
        public IActionResult BuscarPorId(int idMedico)
        {
            return Ok(_medicoRepository.BuscarPorId(idMedico));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="novoMedico"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult Cadastrar(Medico novoMedico)
        {
            _medicoRepository.Cadastrar(novoMedico);
            return StatusCode(201);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMedico"></param>
        /// <param name="medicoAtualizado"></param>
        /// <returns></returns>
        [HttpPut("{idMedico}")]
        public IActionResult AtualizarMedi(int idMedico, Medico medicoAtualizado)
        {
            _medicoRepository.Atualizar(idMedico, medicoAtualizado);

            return StatusCode(204);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="idMedico"></param>
        /// <returns></returns>
        [HttpDelete("{idMedico}")]
        public IActionResult Deletar(int idMedico)
        {
            _medicoRepository.Deletar(idMedico);
            return StatusCode(204);
        }
    }
}
