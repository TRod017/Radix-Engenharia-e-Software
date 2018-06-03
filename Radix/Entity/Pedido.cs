using Entidade.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Pedido : IEntity
    {
        [Key]
        public int Id { get; set; }

        public Guid TokenLoja { get; set; }
        public int IdAdquirente { get; set; }
        public Decimal Valor { get; set; }
        public Cliente Cliente { get; set; }
    }
}
