using Entity.Enum;
using System;

namespace Entity
{
    public class CartaoDeCredito
    {

        /// <summary>
        /// Chave do cartão de crédito. Utilizado para identificar um cartão de crédito no gateway
        /// </summary>
        public Guid InstantBuyKey { get; set; }

        /// <summary>
        /// Número do cartão de crédito
        /// </summary>
        public string Numero { get; set; }

        /// <summary>
        /// Titular do cartão
        /// </summary>
        public string Nome { get; set; }

        /// <summary>
        /// Código de segurança - CVV
        /// </summary>
        public string CodigoSeguranca { get; set; }

        /// <summary>
        /// Mês e Ano de expiração do cartão de crédito
        /// </summary>
        public string Validade { get; set; }

        #region CreditCardBrand

        /// <summary>
        /// Bandeira do cartão de crédito
        /// </summary>
        private string BandeiraCampo
        {
            get
            {
                if (this.Bandeira == null) { return null; }
                return this.Bandeira.Value.ToString();
            }
            set
            {
                if (value == null)
                {
                    this.Bandeira = null;
                }
                else
                {
                    this.Bandeira = (BandeiraCartaoDeCreditoEnum)System.Enum.Parse(typeof(BandeiraCartaoDeCreditoEnum), value);
                }
            }
        }

        /// <summary>
        /// Bandeira do cartão de crédito
        /// </summary>
        public Nullable<BandeiraCartaoDeCreditoEnum> Bandeira { get; set; }

        #endregion
    }
}
