using System.ComponentModel.DataAnnotations;
using Sala.Model;

namespace Sala.ViewModel
{
    public class OrdemServicoCreateViewModel
    {
        [Required(ErrorMessage = "CampoObrigatorio")]
        public int ChamadoId { get; set; }

        [Required(ErrorMessage = "CampoObrigatorio")]
        public StatusOrdemServicoEnum statusOrdemServico { get; set; }

        [Required(ErrorMessage = "CampoObrigatorio")]
        public DateTime DataCriacao {get; set; }

    }
}