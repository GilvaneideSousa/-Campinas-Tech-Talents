using Microsoft.AspNetCore.Mvc;
using Minha1Conexão.Domain.Model;
using System;
using System.Collections.Generic;

namespace Minha1Conexão.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepo;
        
        public UsuarioController(IUsuarioRepository usuarioRepo)
        {
            _usuarioRepo = usuarioRepo;
        }

        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {
            try
            {
                if (string.IsNullOrEmpty(usuario.Nome)) || string.IsNullOrEmpty(usuario.Senha))
                        return BadRequest("Usuário não informou Nome ou Senha.");

                _usuarioRepo.Incluir(usuario);
                return Ok("Usuário Salvo com sucesso.")
            }
            catch (Exception ex)
            {
                return StatusCode(500);
            }
        }

        [HttpPut("{id}")]
        public IEnumerable<TurmaProfessor> Put([FromBody] TurmaProfessor tp)
        {
            _repo.Alterar(tp);
            return _repo.SelecionarTudo();
        }

        [HttpDelete("{id}")]
        public IEnumerable<TurmaProfessor> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTudo();
        }
    }
}
