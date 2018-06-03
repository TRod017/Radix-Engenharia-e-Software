using Entidade.Interfaces;
using System;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class LojaAdquirente : IEntity
    {
        [Key]
        public int Id { get; private set; }

        public DateTime Data { get; set; }

        public int AdquirenteId { get; set; }
        public Adquirente Adquirente { get; set; }

        public int LojaId { get; set; }
        public Loja Loja { get; set; }
    }
}
