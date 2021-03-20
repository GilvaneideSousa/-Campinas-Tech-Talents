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
    public class TurmaProfessorController : ControllerBase
    {
        private readonly ITurmaProfessorRepository _repo;
        
        public TurmaProfessorController(ITurmaProfessorRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public IEnumerable<TurmaProfessor> Get()
        {
            return _repo.SelecionarTudoCompleto();
        }

        [HttpGet("{id}")]
        public TurmaProfessor Get(int id)
        {
            return _repo.Selecionar(id);
        }

        [HttpPost]
        public IEnumerable<TurmaProfessor> Post([FromBody] TurmaProfessor tp)
        {
            _repo.Incluir(tp);
            return _repo.SelecionarTudo();
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
