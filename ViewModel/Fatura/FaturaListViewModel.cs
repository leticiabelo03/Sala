using System.ComponentModel.DataAnnotations;
using Sala.Model;

namespace Sala.ViewModel
{
    public class FaturaListViewModel
    {
        public required string Id { get; set; }
        public required string OrdemServicoId { get; set; }
        public decimal ValorTotal { get; set; }
        public StatusFaturaEnum Status {get; set; }
        public DateTime DataGeracao {get; set; }
        public DateTime DataVencimento {get; set; }

    }
}