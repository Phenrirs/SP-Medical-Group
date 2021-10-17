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
    public class TipoUsuariosController : ControllerBase
    {
        private ITipoUsuarioRepository _tipoUsuarioRepository { get; set; }

        public TipoUsuariosController()
        {
            _tipoUsuarioRepository = new TipoUsuarioRepository();
        }

        /// <summary>
        /// Listar todos os tipos de usuários!
        /// </summary>
        /// <returns>Lista de tipos de usuários!</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(_tipoUsuarioRepository.ListarTodos());
        }

        /// <summary>
        /// Buscar tipos de usuários através dos ids!
        /// </summary>
        /// <param name="idTipoUser">Id do tipo usuário que será buscado!</param>
        /// <returns>Tipo de usuário buscado!</returns>
        [HttpGet("{idTipoUser}")]
        public IActionResult BuscarPorId(int idTipoUser)
        {
            return Ok(_tipoUsuarioRepository.BuscarPorId(idTipoUser));
        }

        /// <summary>
        /// Cadastrar tipos de usuários!
        /// </summary>
        /// <param name="novaTipoUser">Objeto tipo de usuário com as novas informações!</param>
        /// <returns>Novo tipo de usuário cadastrado</returns>
        [HttpPost]
        public IActionResult Cadastrar(TipoUsuario novaTipoUser)
        {
            _tipoUsuarioRepository.Cadastrar(novaTipoUser);
            return StatusCode(201);
        }

        /// <summary>
        /// Atualizar tipos de usuários já cadastrados!
        /// </summary>
        /// <param name="idTipoUser">id do tipo de usuário que será atualizado!</param>
        /// <param name="tipoUserAtualizado">Objeto entidade tipo usuário contendo as novas informações!</param>
        /// <returns>Tipo de usuário atualizado!</returns>
        [HttpPut("{idTipoUser}")]
        public IActionResult AtualizarEspeci(int idTipoUser, TipoUsuario tipoUserAtualizado)
        {
            _tipoUsuarioRepository.Atualizar(idTipoUser, tipoUserAtualizado);

            return StatusCode(204);
        }

        /// <summary>
        /// Deletar tipos de usuários cadastrados!
        /// </summary>
        /// <param name="idTipoUser">id do tipo de usuário que será deletado!</param>
        /// <returns>Tipo de usuário deletado!</returns>
        [HttpDelete("{idTipoUser}")]
        public IActionResult Deletar(int idTipoUser)
        {
            _tipoUsuarioRepository.Deletar(idTipoUser);
            return StatusCode(204);
        }
    }
}
