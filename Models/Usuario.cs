using System.ComponentModel.DataAnnotations;

namespace BeachSys.Models
{
    public class Usuario
    {
        [Key]
        public int ID { get; set; }

        [MinLength(3, ErrorMessage = "Informe no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "Excedeu o tamanho permitido")]
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string Nome { get; set; }

        [ValidaCPF(ErrorMessage = "CPF inválido")]
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string CPF { get; set; }
        
        [MinLength(3, ErrorMessage = "Informe no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "Excedeu o tamanho permitido")]
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string Email { get; set; }
        public virtual Compartimento Compartimento { get; set; }
    }
}