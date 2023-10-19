using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DivTech.Models
{
    public class AddFornecedorViewModel
    {
        
        [Required(ErrorMessage = "O nome não pode ser vazio!")]
        [StringLength(100, ErrorMessage = "O Nome pode conter apenas 100 caracteres!")]
        public string Nome { get; set; } = ""; // 0 - 100
        
        [Required(ErrorMessage = "O CNPJ não pode ser vazio!")]
        [StringLength(14, ErrorMessage = "CNPJ inválido!", MinimumLength = 14)]
        public string CNPJ { get; set; } = ""; // 14 - 14
        public int Especialidade { get; set; } = 1;
        
        [Required(ErrorMessage = "O CEP não pode ser vazio!")]
        [StringLength(8, ErrorMessage = "CEP inválido!", MinimumLength = 8)]
        public string CEP { get; set; } = ""; // 8 - 8
        
        [Required(ErrorMessage = "O Endereço não pode ser vazio!")]
        [StringLength(255, ErrorMessage = "O Endereço pode conter apenas 100 caracteres!")]
        public string Endereco { get; set; } = ""; // 0 - 255
    }
}
