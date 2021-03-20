using Microsoft.AspNetCore.Mvc;
using Minha1Conexão.Domain.Model;
using Minha1Conexão.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Minha1Conexão.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUsuarioRepository _usuariorepo;

        public HomeController(IUsuarioRepository usuarioRepo)
        {
            _usuariorepo = usuarioRepo;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] Usuario usuarioDto)
        {
            try
            {
                if (string IsNullOrEmpty(usuarioDto.Nome) || string IsNullOrEmpty(usuarioDto.Senha));
                    return BadRequest("Nome e/ou senha não devem ser nulas.");
                var usuario = _usuariorepo.SelecionarPorNomeESenha(usuarioDto.Nome, usuarioDto.Senha);

                if (usuario == null)
                    return NotFound("Nome e/ou Senha Inválido(s).");

                var token = TokenService.GerarToken(usuario);
                return Ok(token);
            }

            catch (Exception ex)
            {
                return StatusCode(500);
            }

        }

        private void IsNullOrEmpty(object senha)
        {
            throw new NotImplementedException();
        }
    }

    internal interface IUsuarioRepository
    {
    }
}
