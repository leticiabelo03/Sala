using System.ComponentModel.DataAnnotations;
using Sala.Model;

namespace Sala.ViewModel
{
    public class FaturaEditViewModel
    {

        [Required(
            ErrorMessageResourceName = "CampoObrigatorio"
        )]
        public decimal ValorTotal { get; set; }

        [Required(
            ErrorMessageResourceName = "CampoObrigatorio"
        )]
        public StatusFaturaEnum Status {get; set; }

        [Required(
            ErrorMessageResourceName = "CampoObrigatorio"
        )]
        public DateTime DataVencimento {get; set; }
    }
}