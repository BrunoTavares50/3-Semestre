using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventPlus.WebAPI.DTO
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(100, ErrorMessage = "O nome pode ter no máximo 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required(ErrorMessage = "O email é obrigatório.")]
        [StringLength(100, ErrorMessage = "O email pode ter no máximo 100 caracteres.")]
        public string Email { get; set; } = string.Empty;

        [Required(ErrorMessage = "A senha é obrigatória.")]
        [StringLength(60, ErrorMessage = "A senha pode ter no máximo 60 caracteres.")]
        public string Senha { get; set; } = string.Empty;
    }
}
