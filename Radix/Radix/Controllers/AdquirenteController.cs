using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Radix.Controllers
{
    [Route("api/[controller]")]
    public class AdquirenteController : Controller
    {
        private IAdquirenteBusiness _adquirenteBusiness;

        public AdquirenteController(IAdquirenteBusiness adquirenteBusiness)
        {
            _adquirenteBusiness = adquirenteBusiness;
        }


        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            //_adquirenteBusiness.Salvar();
            return new string[] { "value1", "value2" };

        }

        // GET api/values/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            //_adquirenteBusiness.Salvar();
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
