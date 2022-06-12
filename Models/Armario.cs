using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace BeachSys.Models
{
    public class Armario
    {
        [Key]
        public int ID { get; set; }
        [MinLength(3, ErrorMessage = "Informe no mínimo 3 caracteres")]
        [MaxLength(100, ErrorMessage = "Excedeu o tamanho permitido")]
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public int PontoX { get; set; }
        [Required(ErrorMessage = "Este campo é obrigatorio")]
        public int PontoY { get; set; }
        public virtual ICollection<Compartimento> Compartimentos { get; set; } = new List<Compartimento>();
        [ForeignKey("Admin")]
        public int AdminID { get; set; }
        public Admin Admin { get; set; }

        public int CompartimentosDisponiveis()
        {
            return Compartimentos.Count(c => c.Disponivel);
        }
    }
}