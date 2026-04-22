using System.ComponentModel.DataAnnotations;
using Sala.Model;

namespace Sala.ViewModel
{
    public class ClienteCreateViewModel
    {
        [Required(ErrorMessageResourceName = "CampoObrigatorio")]
        public required string Nome {get; set; }

        [Required(ErrorMessageResourceName = "CampoObrigatorio")]
        public required string Email {get; set; }

        [Required(ErrorMessageResourceName = "CampoObrigatorio")]
        public required string Telefone {get; set; }
    }
}