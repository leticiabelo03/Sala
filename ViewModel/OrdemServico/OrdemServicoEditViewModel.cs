using System.ComponentModel.DataAnnotations;
using Sala.Model;

namespace Sala.ViewModel
{
    public class OrdemServicoEditViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "CampoObrigatorio")]
        public StatusOrdemServicoEnum statusOrdemServico { get; set; }

        public DateTime DataConclusao { get; set; }

        [Required(ErrorMessage = "CampoObrigatorio")]
        public decimal ValorTotal { get; set; }
    }
}