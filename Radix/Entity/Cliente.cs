using System;

namespace Entity
{
    public class Cliente
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Email { get; set; }
        public DateTime Nascimento { get; set; }
        public Endereco Endreco { get; set; }
        public Endereco EnderecoCobranca { get; set; }
        public CartaoDeCredito CartaoDeCredito { get; set; }
    }
}
