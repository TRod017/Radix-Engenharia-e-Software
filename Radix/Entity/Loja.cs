using Entidade.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Entity
{
    public class Loja : IEntity
    {
        [Key]
        public int Id { get; private set; }

        [Required]
        [StringLength(18)]
        [Display(Name = "CNPJ")]
        public string CNPJ { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required]
        [Display(Name = "Possui Antifraude Habilitado")]
        public bool IsAntiFraudeEnabled { get; set; }

        public Guid Token { get; set; }

        public List<LojaAdquirente> LojaAdquirentes { get; set; }
    }
}
