using System.ComponentModel.DataAnnotations;
using Sala.Model;

namespace Sala.ViewModel
{
    public class UsuarioCreateViewModel
    {
        [Required(ErrorMessage = "O campo é obrigatório")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [EmailAddress]
        public required string Email { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [DataType(DataType.Password)]
        public string? Senha { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public PerfilUsuarioEnum PerfilUsuario {get; set; }
    }
}

