using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.SignalR;

namespace Sala.Model
{
    public class Contrato
    {

        [Column("id")]
        public int Id {get; set; }

        [Column("clienteId")]
        public int ClienteId {get; set; }

        [Column("dataInicio")]
        public DateOnly DataInicio {get; set; }

        [Column("dataFim")]
        public DateOnly DataFim {get; set; }

        [Column("valorMensal")]
        public decimal ValorMensal {get; set; }

        [Column("ativo")]
        public bool Ativo {get; set; }

        // Relacionamentos
        public Cliente? Cliente {get; set; }
    }
}