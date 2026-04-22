using System.ComponentModel.DataAnnotations;
using Sala.Model;

namespace Sala.ViewModel
{
    public class PagamentoCreateViewModel
    {
        public int FaturaId { get; set; }

        public decimal ValorFatura { get; set; }

        [Required(ErrorMessage = "CampoObrigatorio")]
        public decimal ValorPago { get; set; }

        [Required(ErrorMessage = "CampoObrigatorio")]
        public MetodoPagamentoEnum Metodo { get; set; }

        public DateTime DataPagamento { get; set; } = DateTime.Now;
    }
}