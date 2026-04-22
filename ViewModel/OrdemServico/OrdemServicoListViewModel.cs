using System.ComponentModel.DataAnnotations;
using Sala.Model;

namespace Sala.ViewModel
{
    public class OrdemServicoListViewModel
    {
        public int Id { get; set; }
        

        public int ChamadoId { get; set; }

        public StatusOrdemServicoEnum statusOrdemServico { get; set; }
        
        public DateTime DataCriacao {get; set; }

        public DateTime DataConclusao {get; set; }

        public decimal ValorTotal {get; set; }
    }
}