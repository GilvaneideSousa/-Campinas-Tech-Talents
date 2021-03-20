using Microsoft.AspNetCore.Mvc;
using Minha1Conexão.Data.Interface;
using Minha1Conexão.Data.Repositoy;
using Minha1Conexão.Domain.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace Minha1Conexão.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurmaAlunoController : ControllerBase
    {
        private readonly ITurmaAlunoRepository _repo;

        public TurmaAlunoController(ITurmaAlunoRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<TurmaAluno> Get()
        
        {
            return _repo.SelecionarTudoCompleto();
        }

        [HttpGet("{id}")]
        public TurmaAluno Get(int id)
        {
            return _repo.Selecionar(id);
        }

        [HttpPost]
        public IEnumerable<TurmaAluno> Post([FromBody] TurmaAluno ta)
        {
            _repo.Incluir(ta);
            return _repo.SelecionarTudo();
        }

        [HttpPut("{id}")]
        public IEnumerable<TurmaAluno> Put([FromBody] TurmaAluno ta)
        {
            _repo.Alterar(ta);
            return _repo.SelecionarTudo();
        }

        [HttpDelete("{id}")]
        public IEnumerable<TurmaAluno> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTudo();
        }
    }
}
