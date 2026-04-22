using System.ComponentModel.DataAnnotations;
using Sala.Model;

namespace Sala.ViewModel
{
    public class PagamentoListViewModel
    {
        public int Id {get; set; }
        public required string FaturaId { get; set; }

        public DateTime DataPagamento { get; set; }

        public decimal ValorPago {get; set; }
        public MetodoPagamentoEnum Metodo {get; set; }

    }
}