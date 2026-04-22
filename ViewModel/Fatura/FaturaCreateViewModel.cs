using System.ComponentModel.DataAnnotations;
using Sala.Model;

namespace Sala.ViewModel
{
    public class FaturaCreateViewModel
    {
        [Required(
            ErrorMessageResourceName = "CampoObrigatorio"
        )]
        public required string OrdemServicoId { get; set; }

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
        public DateTime DataGeracao {get; set; }
    }
}