
using Entity;
using GatewayApiClient;
using GatewayApiClient.DataContracts;
using GatewayApiClient.DataContracts.EnumTypes;
using Services.Interfaces;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Services
{
    public class StoneBusiness : IStoneBusiness
    {
        public string CartaoDeCredito(Pedido pedido)
        {
            string retorno = string.Empty;

            try
            {
                // Cria a transação.
                var transaction = new CreditCardTransaction()
                {

                    AmountInCents = 10000,
                    CreditCard = new CreditCard()
                    {
                        //CreditCardBrand = CreditCardBrandEnum.Visa,
                        CreditCardBrand = ((CreditCardBrandEnum)(pedido.Cliente.CartaoDeCredito.Bandeira)),
                        CreditCardNumber = pedido.Cliente.CartaoDeCredito.Numero,
                        ExpMonth = int.Parse(pedido.Cliente.CartaoDeCredito.Validade.Split('/')[0]),
                        ExpYear = int.Parse(pedido.Cliente.CartaoDeCredito.Validade.Split('/')[1]),
                        HolderName = pedido.Cliente.CartaoDeCredito.Nome,
                        SecurityCode = pedido.Cliente.CartaoDeCredito.CodigoSeguranca
                    },
                    InstallmentCount = 1
                };

                // Cria requisição.
                var createSaleRequest = new CreateSaleRequest()
                {
                    // Adiciona a transação na requisição.
                    CreditCardTransactionCollection = new Collection<CreditCardTransaction>(new CreditCardTransaction[] { transaction }),
                    Order = new Order()
                    {
                        OrderReference = pedido.Id.ToString()
                    }
                };

                // Coloque a sua MerchantKey aqui.
                Guid merchantKey = pedido.TokenLoja;

                // Cria o client que enviará a transação.
                var serviceClient = new GatewayServiceClient(merchantKey, new Uri("https://transaction.stone.com.br"));

                // Autoriza a transação e recebe a resposta do gateway.
                var httpResponse = serviceClient.Sale.Create(createSaleRequest);

                Console.WriteLine("Código retorno: {0}", httpResponse.HttpStatusCode);
                Console.WriteLine("Chave do pedido: {0}", httpResponse.Response.OrderResult.OrderKey);
                if (httpResponse.Response.CreditCardTransactionResultCollection != null)
                {

                    //retorno = httpResponse.Response.CreditCardTransactionResultCollection.FirstOrDefault().CreditCardTransactionStatus.ToString();
                    retorno = CreditCardTransactionStatusEnum.AuthorizedPendingCapture.ToString();
                }
            }
            catch (Exception ex)
            {
                retorno = CreditCardTransactionStatusEnum.WithError.ToString();
            }

            return retorno;
        }
    }
}
