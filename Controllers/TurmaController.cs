using Microsoft.AspNetCore.Mvc;
using Minha1Conexão.Data.Interface;
using Minha1Conexão.Domain.Model;
using System.Collections.Generic;


namespace Minha1Conexão.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaController : ControllerBase
    {
        private readonly ITurmaRepository _repo;

        public TurmaController(ITurmaRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Turma> Get()
        {
            return _repo.SelecionarTudo();
        }

        [HttpGet("{id}")]
        public Turma Get(int id)
        {
            return _repo.Selecionar(id);
        }

        [HttpPost]
        public IEnumerable<Turma> Post([FromBody] Turma t)
        {
            _repo.Incluir(t);
            return _repo.SelecionarTudo();
        }

        [HttpPut("{id}")]
        public IEnumerable<Turma> Put([FromBody] Turma t)
        {
            _repo.Alterar(t);
            return _repo.SelecionarTudo();
        }
   
        [HttpDelete("{id}")]
        public IEnumerable<Turma> Delete(int id)
        {
        _repo.Excluir(id);
        return _repo.SelecionarTudo();
        }
    }
}

