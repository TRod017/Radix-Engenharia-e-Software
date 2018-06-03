using Services.Util;
using System.Text;
using RestSharp;
using Services.Interfaces;
using Entity;
using GatewayApiClient.DataContracts.EnumTypes;

namespace Services
{
    public class CieloBusiness : ICieloBusiness
    {
        public string CartaoDeCredito(Pedido pedido)
        {
            StringBuilder parametros = new StringBuilder();

            string aqui = "AQUI";

            parametros.Append("{");
            parametros.AppendLine();
            parametros.Append("\"MerchantOrderId\":");
            parametros.Append(string.Format("\"{0}\",", pedido.TokenLoja));
            parametros.AppendLine();
            parametros.Append("\"Customer\":{");
            parametros.AppendLine();
            parametros.Append("\"Name\":");
            parametros.Append(string.Format("\"{0}\",", pedido.Cliente.Nome));
            parametros.AppendLine();
            parametros.Append("\"Identity\":");
            parametros.Append(string.Format("\"{0}\",", pedido.Cliente.CPF));
            parametros.AppendLine();
            parametros.Append("\"IdentityType\":\"CPF\",");
            parametros.AppendLine();
            parametros.Append("\"Email\":");
            parametros.Append(string.Format("\"{0}\",", pedido.Cliente.Email));
            parametros.AppendLine();
            parametros.Append("\"Birthdate\":");
            parametros.Append(string.Format("\"{0}\",", pedido.Cliente.Nascimento));
            parametros.AppendLine();
            parametros.Append("\"Address\":{");
            parametros.AppendLine();
            parametros.Append("\"Street\":");
            parametros.Append(string.Format("\"{0}\",", pedido.Cliente.Endreco.Rua));
            parametros.AppendLine();
            parametros.Append("\"Number\":");
            parametros.Append(string.Format("\"{0}\",", pedido.Cliente.Endreco.Numero));
            parametros.AppendLine();
            parametros.Append("\"Complement\":");
            parametros.Append(string.Format("\"{0}\",", pedido.Cliente.Endreco.Complemento));
            parametros.AppendLine();
            parametros.Append("\"ZipCode\":");
            parametros.Append(string.Format("\"{0}\",", pedido.Cliente.Endreco.CEP));
            parametros.AppendLine();
            parametros.Append("\"City\":");
            parametros.Append(string.Format("\"{0}\",", pedido.Cliente.Endreco.Cidade));
            parametros.AppendLine();
            parametros.Append("\"State\":");
            parametros.Append(string.Format("\"{0}\",", pedido.Cliente.Endreco.Estado));
            parametros.AppendLine();
            parametros.Append("\"Country\":");
            parametros.Append(string.Format("\"{0}\",", pedido.Cliente.Endreco.Pais));
            parametros.AppendLine();
            parametros.Append("},");
            parametros.AppendLine();
            parametros.Append("\"DeliveryAddress\": {");
            parametros.AppendLine();
            parametros.Append("\"Street\":");
            parametros.Append(string.Format("\"{0}\",", pedido.Cliente.EnderecoCobranca.Rua));
            parametros.AppendLine();
            parametros.Append("\"Number\":");
            parametros.Append(string.Format("\"{0}\",", pedido.Cliente.EnderecoCobranca.Numero));
            parametros.AppendLine();
            parametros.Append("\"Complement\":");
            parametros.Append(string.Format("\"{0}\",", pedido.Cliente.EnderecoCobranca.Complemento));
            parametros.AppendLine();
            parametros.Append("\"ZipCode\":");
            parametros.Append(string.Format("\"{0}\",", pedido.Cliente.EnderecoCobranca.CEP));
            parametros.AppendLine();
            parametros.Append("\"City\":");
            parametros.Append(string.Format("\"{0}\",", pedido.Cliente.EnderecoCobranca.Cidade));
            parametros.AppendLine();
            parametros.Append("\"State\":");
            parametros.Append(string.Format("\"{0}\",", pedido.Cliente.EnderecoCobranca.Estado));
            parametros.AppendLine();
            parametros.Append("\"Country\":");
            parametros.Append(string.Format("\"{0}\",", pedido.Cliente.EnderecoCobranca.Pais));
            parametros.AppendLine();
            parametros.Append("}");
            parametros.AppendLine();
            parametros.Append("},");
            parametros.AppendLine();
            parametros.Append("\"Payment\":{ ");
            parametros.AppendLine();
            parametros.Append("\"Type\":\"CreditCard\",");
            parametros.AppendLine();
            parametros.Append("\"Amount\":");
            parametros.Append(string.Format("\"{0}\",", pedido.Valor));
            parametros.AppendLine();
            parametros.Append("\"Currency\":\"BRL\",");
            parametros.AppendLine();
            parametros.Append("\"Country\":\"BRA\",");
            parametros.AppendLine();
            parametros.Append("\"Provider\":\"Simulado\",");
            parametros.AppendLine();
            parametros.Append("\"ServiceTaxAmount\":0,");
            parametros.AppendLine();
            parametros.Append("\"Installments\":1,");
            parametros.AppendLine();
            parametros.Append("\"Interest\":\"ByMerchant\",");
            parametros.AppendLine();
            parametros.Append("\"Capture\":false,");
            parametros.AppendLine();
            parametros.Append("\"Authenticate\":false,");
            parametros.AppendLine();
            parametros.Append("\"Recurrent\": false,");
            parametros.AppendLine();
            parametros.Append("\"SoftDescriptor\":\"123456789ABCD\",");
            parametros.AppendLine();
            parametros.Append("\"CreditCard\":{");
            parametros.AppendLine();
            parametros.Append("\"CardNumber\":");
            parametros.Append(string.Format("\"{0}\",", pedido.Cliente.CartaoDeCredito.Numero));
            parametros.AppendLine();
            parametros.Append("\"Holder\":");
            parametros.Append(string.Format("\"{0}\",", pedido.Cliente.CartaoDeCredito.Nome));
            parametros.AppendLine();
            parametros.Append("\"ExpirationDate\":");
            parametros.Append(string.Format("\"{0}\",", pedido.Cliente.CartaoDeCredito.Validade));
            parametros.AppendLine();
            parametros.Append("\"SecurityCode\":");
            parametros.Append(string.Format("\"{0}\",", pedido.Cliente.CartaoDeCredito.CodigoSeguranca));
            parametros.AppendLine();
            parametros.Append("\"SaveCard\":\"false\",");
            parametros.AppendLine();
            parametros.Append("\"Brand\":");
            parametros.Append(string.Format("\"{0}\"", pedido.Cliente.CartaoDeCredito.Bandeira));
            parametros.AppendLine();
            parametros.Append("}");
            parametros.AppendLine();
            parametros.Append("}");
            parametros.AppendLine();
            parametros.Append("}");

            string json = JsonFormatting.Ident(parametros.ToString());

            var client = new RestClient("http:///%7B%7BapiUrl%7D%7D/1/sales");
            var request = new RestRequest(Method.POST);
            request.AddHeader("postman-token", "87b55406-11be-463c-e8b6-d5cea97c8886");
            request.AddHeader("cache-control", "no-cache");
            request.AddHeader("merchantkey", "{{" + pedido.TokenLoja + "}}");
            request.AddHeader("merchantid", "{{" + pedido.TokenLoja + "}}");
            request.AddHeader("content-type", "application/json");
            request.AddParameter("application/json", parametros, ParameterType.RequestBody);
            //IRestResponse response = client.Execute(request);

            //return response.Content;

            return CreditCardTransactionStatusEnum.AuthorizedPendingCapture.ToString();
        }
    }
}
