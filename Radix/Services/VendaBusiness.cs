using Entity;
using Services.Interfaces;
using System.Linq;

namespace Services
{
    public class VendaBusiness : IVendaBusiness
    {
        private readonly ILojaBusiness _lojaBusiness;
        private readonly IAntiFraudeBusiness _antiFraudeBusiness;
        private readonly ITransacaoBusiness _transacaoBusiness;
        private readonly ICieloBusiness _cieloBusiness;
        private readonly IStoneBusiness _stoneBusiness;

        public VendaBusiness(ILojaBusiness lojaBusiness,
                            IAntiFraudeBusiness antiFraudeBusiness,
                            ITransacaoBusiness transacaoBusiness,
                            ICieloBusiness cieloBusiness,
                            IStoneBusiness stoneBusiness
                            )
        {
            _lojaBusiness = lojaBusiness;
            _antiFraudeBusiness = antiFraudeBusiness;
            _transacaoBusiness = transacaoBusiness;
            _cieloBusiness = cieloBusiness;
            _stoneBusiness = stoneBusiness;
        }

        public string CartadoDeCredito(Pedido pedido)
        {
            string retorno = string.Empty;

            Loja loja = _lojaBusiness.Selecionar(pedido.TokenLoja);

            if (loja == null)
            {
                throw new System.ArgumentException("Loja não cadastrada!");
            }

            if(!loja.LojaAdquirentes.Any(a => a.Adquirente.Id.Equals(pedido.IdAdquirente)))
            {
                throw new System.ArgumentException("Adquirente não cadastrado para essa loja!");
            }

            if (loja.IsAntiFraudeEnabled)
            {
                string resultadoAntiFraude = _antiFraudeBusiness.Analisar(pedido);

                if (!resultadoAntiFraude.Equals("APA"))
                {
                    throw new System.ArgumentException(resultadoAntiFraude);
                }
            }

            _transacaoBusiness.Salvar(pedido);

            switch (pedido.IdAdquirente)
            {
                case 1:
                    break;
                case 2:
                    retorno = _cieloBusiness.CartaoDeCredito(pedido);
                    break;
                case 3:
                    retorno = _stoneBusiness.CartaoDeCredito(pedido);
                    break;
                default:
                    break;
            }

            return retorno;
        }
    }
}
