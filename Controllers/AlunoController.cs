using Microsoft.AspNetCore.Mvc;
using Minha1Conexão.Data.Interface;
using Minha1Conexão.Domain;
using System.Collections.Generic;

namespace Minha1Conexão.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _repo;

        public AlunoController(IAlunoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Aluno> Get()
        {
            return _repo.SelecionarTudo();
        }

        [HttpGet("{id}")]
        public Aluno Get(int id)
        {
            return _repo.Selecionar(id);
        }

        [HttpPost]
        public IEnumerable<Aluno> Post([FromBody] Aluno aluno)
        {
            _repo.Incluir(aluno);
            return _repo.SelecionarTudo();
        }

        [HttpPut("{id}")]
        public IEnumerable<Aluno> Put(int id, [FromBody] Aluno aluno)
        {
            _repo.Alterar(aluno);
            return _repo.SelecionarTudo();
        }

        [HttpDelete("{id}")]
        public IEnumerable<Aluno> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTudo();
        }
    }
}
