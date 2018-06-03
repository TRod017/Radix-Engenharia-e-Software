using Entity;
using Repository.Interfaces;
using Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Services
{
    public class TransacaoBusiness : ITransacaoBusiness
    {
        private readonly ITransacaoRepository _transacaoRepository;
        private readonly ILojaBusiness _lojaBusiness;
        private readonly IAdquirenteBusiness _adquirenteBusiness;

        public TransacaoBusiness(ITransacaoRepository transacaoRepository, ILojaBusiness lojaBusiness, IAdquirenteBusiness adquirenteBusiness)
        {
            _transacaoRepository = transacaoRepository;
            _lojaBusiness = lojaBusiness;
            _adquirenteBusiness = adquirenteBusiness;
        }

        public IEnumerable<Transacao> Listar()
        {
            return _transacaoRepository.Listar();
        }

        public IEnumerable<Transacao> Listar(Guid tokenLoja)
        {
            return _transacaoRepository.Listar(tokenLoja).ToList();
        }

        public Transacao Selecionar(int id)
        {
            return _transacaoRepository.Selecionar(id);
        }

        public bool Deletar(int id)
        {
            Transacao transacao = this.Selecionar(id);

            return _transacaoRepository.Deletar(transacao);
        }

        public bool Salvar(Transacao transacao)
        {
            return _transacaoRepository.Salvar(transacao);
        }

        public bool Salvar(Pedido pedido)
        {
            Transacao transacao = new Transacao()
            {
                Loja = _lojaBusiness.Selecionar(pedido.TokenLoja),
                Adquirente = _adquirenteBusiness.Selecionar(pedido.IdAdquirente),
                Data = DateTime.Now,
                Numero = Guid.NewGuid(),
                NumeroPedido = pedido.Id,
                Valor = pedido.Valor
            };

            return _transacaoRepository.Salvar(transacao);
        }
    }
}
