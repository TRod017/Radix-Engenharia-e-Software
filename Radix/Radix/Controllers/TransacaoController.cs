using System;
using System.Collections.Generic;
using Entity;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace Radix.Controllers
{
    [Route("api/[controller]")]
    public class TransacaoController : Controller
    {
        private ITransacaoBusiness _transacaoBusiness;

        public TransacaoController(ITransacaoBusiness transacaoBusiness)
        {
            _transacaoBusiness = transacaoBusiness;
        }

        // GET api/values/5
        [HttpGet("{TokenLoja}")]
        public IEnumerable<Transacao> Get(Guid TokenLoja)
        {
            return _transacaoBusiness.Listar(TokenLoja);
        }
    }
}
