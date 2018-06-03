using Entidade.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Transacao : IEntity
    {
        [Key]
        public int Id { get; private set; }

        public int LojaId { get; set; }
        public virtual Loja Loja { get; set; }

        public int AdquirenteId { get; set; }
        public virtual Adquirente Adquirente { get; set; }

        public DateTime Data { get; set; }
        public Guid Numero { get; set; }
        public int NumeroPedido { get; set; }
        public Decimal Valor { get; set; }
    }
}
