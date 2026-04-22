using System.ComponentModel.DataAnnotations;


namespace Sala.ViewModel
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo é obrigatório")]
        [EmailAddress]
        public required string Email { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        [DataType(DataType.Password)]
        public required string Senha { get; set; }
    }
}
