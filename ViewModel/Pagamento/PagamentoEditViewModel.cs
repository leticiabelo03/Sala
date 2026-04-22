using System.ComponentModel.DataAnnotations;
using Sala.Model;

namespace Sala.ViewModel
{
    public class PagamentoEditViewModel
    {
        [Required(
            ErrorMessageResourceName = "CampoObrigatorio"
        )]
        public DateTime DataPagamento { get; set; }

        [Required(
            ErrorMessageResourceName = "CampoObrigatorio"
        )]
        public decimal ValorPago {get; set; }

        [Required(
            ErrorMessageResourceName = "CampoObrigatorio"
        )]
        public MetodoPagamentoEnum Metodo {get; set; }


    }
}