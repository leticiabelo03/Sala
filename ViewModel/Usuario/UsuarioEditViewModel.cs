using System.ComponentModel.DataAnnotations;
using Sala.Model;

namespace Sala.ViewModel
{
    public class UsuarioEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public required string Nome { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public required string Email { get; set; }

        
        [Required(ErrorMessage = "O campo é obrigatório")]
        public PerfilUsuarioEnum PerfilUsuario {get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public string? Senha {get; set; }

        // [Required(ErrorMessageResourceName = "CampoObrigatorio",
        //     ErrorMessageResourceType = typeof(SharedResource))]
        // public required string Senha { get; set; }
    }
}
