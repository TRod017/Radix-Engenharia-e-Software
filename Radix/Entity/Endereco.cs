namespace Entity
{
    public class Endereco
    {
        /// <summary>
        /// País. Opções: Brazil, USA, Argentina, Bolivia, Chile, Colombia, Uruguay, Mexico, Paraguay
        /// </summary>
        public string Pais { get; set; }

        /// <summary>
        /// Estado
        /// </summary>
        public string Estado { get; set; }

        /// <summary>
        /// Cidade
        /// </summary>
        public string Cidade { get; set; }

        /// <summary>
        /// Logradouro
        /// </summary>
        public string Rua { get; set; }

        /// <summary>
        /// Número
        /// </summary>
        public int Numero { get; set; }

        /// <summary>
        /// Complemento
        /// </summary>
        public string Complemento { get; set; }

        /// <summary>
        /// CEP
        /// </summary>
        public string CEP { get; set; }
    }
}
