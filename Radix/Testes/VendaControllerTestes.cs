using Entity;
using Entity.Enum;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Radix.Controllers;
using Services;
using Services.Interfaces;
using System;

namespace Radix.Testes
{
    [TestClass]
    public class VendaControllerTestes
    {
        private IVendaBusiness _vendaBusiness;

        [TestInitialize]
        public void Initialize()
        {
            _vendaBusiness = null;
        }

        [TestMethod]
        public void StoneSucesso()
        {
            // Arrange
            var controller = new VendaController(_vendaBusiness);


            Pedido pedido = new Pedido()
            {
                TokenLoja = Guid.Parse("3B462321-72C7-4F72-B10A-4DCB00A2177A"),
                IdAdquirente = 2,
                Id = 123457,
                Valor = ((decimal)400.03),
            };

            pedido.Cliente = new Cliente()
            {
                Nome = "Comprador Teste",
                CPF = "11225468954",
                Email = "compradorteste@teste.com",
                Nascimento = DateTime.Parse("1991-01-02"),
            };

            pedido.Cliente.Endreco = new Endereco()
            {
                Rua = "Rua Teste",
                Numero = 123,
                Complemento = "AP 123",
                CEP = "12345987",
                Cidade = "Rio de Janeiro",
                Estado = "RJ",
                Pais = "BRA"
            };


            pedido.Cliente.EnderecoCobranca = new Endereco()
            {
                Rua = "Rua Teste",
                Numero = 123,
                Complemento = "AP 123",
                CEP = "12345987",
                Cidade = "Rio de Janeiro",
                Estado = "RJ",
                Pais = "BRA"
            };

            pedido.Cliente.CartaoDeCredito = new CartaoDeCredito()
            {
                Numero = "4024007197692931",
                Nome = "Teste Holder",
                Validade = "12/2021",
                CodigoSeguranca = "123",
                Bandeira = BandeiraCartaoDeCreditoEnum.Visa
            };


            // Act
            var result = controller.Post(pedido);

            // Assert
            Assert.AreEqual("CreditCardTransactionStatusEnum.AuthorizedPendingCapture", result);
        }

        [TestMethod]
        public void StoneFalha()
        {
            // Arrange
            var controller = new VendaController(_vendaBusiness);


            Pedido pedido = new Pedido()
            {
                TokenLoja = Guid.Parse("3B462321-72C7-4F72-B10A-4DCB00A21a7A"),
                IdAdquirente = 2,
                Id = 123457,
                Valor = ((decimal)400.03),
            };

            pedido.Cliente = new Cliente()
            {
                Nome = "Comprador Teste",
                CPF = "11225468954",
                Email = "compradorteste@teste.com",
                Nascimento = DateTime.Parse("1991-01-02"),
            };

            pedido.Cliente.Endreco = new Endereco()
            {
                Rua = "Rua Teste",
                Numero = 123,
                Complemento = "AP 123",
                CEP = "12345987",
                Cidade = "Rio de Janeiro",
                Estado = "RJ",
                Pais = "BRA"
            };


            pedido.Cliente.EnderecoCobranca = new Endereco()
            {
                Rua = "Rua Teste",
                Numero = 123,
                Complemento = "AP 123",
                CEP = "12345987",
                Cidade = "Rio de Janeiro",
                Estado = "RJ",
                Pais = "BRA"
            };

            pedido.Cliente.CartaoDeCredito = new CartaoDeCredito()
            {
                Numero = "4024007197692931",
                Nome = "Teste Holder",
                Validade = "12/2021",
                CodigoSeguranca = "123",
                Bandeira = BandeiraCartaoDeCreditoEnum.Visa
            };


            // Act
            var result = controller.Post(pedido);

            // Assert
            Assert.AreEqual("CreditCardTransactionStatusEnum.AuthorizedPendingCapture", result);
        }
    }
}
