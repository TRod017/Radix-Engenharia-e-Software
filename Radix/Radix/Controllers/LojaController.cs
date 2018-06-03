using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Services.Interfaces;

namespace Radix.Controllers
{
    [Route("api/[controller]")]
    public class LojaController : Controller
    {
        private ILojaBusiness _LojaBusiness;

        public LojaController(ILojaBusiness LojaBusiness)
        {
            _LojaBusiness = LojaBusiness;
        }


        // GET api/values
        [HttpGet]
        public IEnumerable<Loja> Get()
        {
            return _LojaBusiness.Listar();
            //return new string[] { "value1", "value2" };

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public Loja Get(int id)
        {
            return _LojaBusiness.Selecionar(id);
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]Loja value)
        {
            if (value == null)
            {
                BadRequest();
            }

            _LojaBusiness.Salvar(value);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]Loja value)
        {
            _LojaBusiness.Alterar();
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _LojaBusiness.Deletar(id);
        }
    }
}
