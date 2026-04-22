using System.ComponentModel.DataAnnotations;
using Sala.Model;

namespace Sala.ViewModel
{
    public class ContratoListViewModel
    {
        public int Id {get; set; }

        public int ClienteId {get; set; }

        public DateOnly DataInicio { get; set; }
        public DateOnly DataFim { get; set; }

        public decimal ValorMensal {get; set; }

        public bool Ativo {get; set; }
    }
}