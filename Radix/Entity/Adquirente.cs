using Entidade.Interfaces;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Adquirente : IEntity
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        public List<LojaAdquirente> LojaAdquirentes { get; set; }
    }
}
