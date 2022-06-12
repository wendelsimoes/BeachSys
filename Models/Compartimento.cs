using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BeachSys.Models
{
    public class Compartimento
    {
        [Key]
        public int Numero { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public int Comprimento { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public int Largura { get; set; }
        public bool Disponivel { get; set; } = true;
        [ForeignKey("Usuario")]
        public int? UsuarioID { get; set; }
        public Usuario Usuario { get; set; }
    }
}