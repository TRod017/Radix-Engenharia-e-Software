using Entity;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Radix.Controllers
{
    [Route("api/[controller]")]
    public class VendaController : Controller
    {
        private IVendaBusiness _vendaBusiness;

        public VendaController(IVendaBusiness vendaBusiness)
        {
            _vendaBusiness = vendaBusiness;
        }

        // POST api/values
        [HttpPost]
        public string Post([FromBody]Pedido pedido)
        {
            return _vendaBusiness.CartadoDeCredito(pedido);
        }
    }
}
