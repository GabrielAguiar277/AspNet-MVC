using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace DivTech.Models
{
    public class FornecedorModel
    {
        
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Nome { get; set; } // 0 - 100
        [Required]
        [StringLength(14, MinimumLength = 14)]
        public string CNPJ { get; set; } // 14 - 14
        [Required]
        public int Especialidade { get; set; }
        [Required]
        [StringLength(8, MinimumLength = 8)]
        public string CEP { get; set; } // 8 - 8
        [Required]
        [StringLength(255, MinimumLength = 255)]
        public string Endereco { get; set; } // 0 - 255


    }
}
