using Microsoft.AspNetCore.Mvc;
using Minha1Conexão.Data.Interface;
using Minha1Conexão.Data.Repositoy;
using Minha1Conexão.Domain;
using Minha1Conexão.Domain.Model;
using System.Collections.Generic;

namespace Minha1Conexão.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorRepository _repo;

        public ProfessorController(IProfessorRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<Professor> Get()
        {
            return _repo.SelecionarTudo();
        }     
       
        [HttpGet("{id}")]
        public Professor Get(int id)
        {
            return _repo.Selecionar(id);
        }

        [HttpPost]
        public IEnumerable<Professor> Post([FromBody] Professor professor)
        {
            _repo.Incluir(professor);
            return _repo.SelecionarTudo();
        }

        [HttpPut("{id}")]
        public IEnumerable<Professor> Put(int id, [FromBody] Professor professor)
        {
            _repo.Alterar(professor);
            return _repo.SelecionarTudo();
        }

        [HttpDelete("{id}")]
        public IEnumerable<Professor> Delete(int id)
        {
            _repo.Excluir(id);
            return _repo.SelecionarTudo();
        }
    }
}
