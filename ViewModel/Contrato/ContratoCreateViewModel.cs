using System.ComponentModel.DataAnnotations;
using Sala.Model;

namespace Sala.ViewModel
{
    public class ContratoCreateViewModel
    {
        [Required(
            ErrorMessageResourceName = "CampoObrigatorio"
        )]
        public required string ClienteId { get; set; }

        [Required(
            ErrorMessageResourceName = "CampoObrigatorio"
        )]
        public DateOnly DataInicio { get; set; }

        [Required(
            ErrorMessageResourceName = "CampoObrigatorio"
        )]
        public DateOnly DataFim { get; set; }

        [Required(
            ErrorMessageResourceName = "CampoObrigatorio"
        )]
        public decimal ValorMensal {get; set; }

    }
}