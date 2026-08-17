using System.ComponentModel.DataAnnotations;

namespace EventPlus.WebAPI.DTO
{
    public class InstituicaoDTO
    {
        [Required(ErrorMessage = "O CNPJ é obigatório.")]
        [StringLength(14, ErrorMessage = "O CNPJ pode ter no máximo 14 caracteres.")]
        public string CNPJ { get; set; } = string.Empty;

        [Required(ErrorMessage = "O NomeFantasia é obrigatório.")]
        [StringLength(100, ErrorMessage = "O NomeFantasia pode ter no máximo 100 caracteres.")]
        public string NomeFantasia { get; set; } = string.Empty;
    }
}
