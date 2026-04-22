using System.ComponentModel.DataAnnotations;
using Sala.Model;

namespace Sala.ViewModel
{
    public class ContratoEditViewModel
    {

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

        [Required(
            ErrorMessageResourceName = "CampoObrigatorio"
        )]
        public bool Ativo {get; set; }
    }
}