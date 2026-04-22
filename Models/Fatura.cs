using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;


namespace Sala.Model
{
    public class Fatura
    {

        [Column("id")]
        public int Id {get; set;}

        [Column("ordemServicoId")]
        public int OrdemServicoId {get; set; }

        [Column("valorTotal")]
        public decimal ValorTotal {get; set; }

        [Column("status")]
        public StatusFaturaEnum Status {get; set;}

        [Column("dataGeracao")]
        public DateTime DataGeracao {get; set; }

        [Column("dataVencimento")]
        public DateTime DataVencimento {get; set; }
            

        // Relacionamentos
        public OrdemServico? OrdemServico {get; set; }
        // public Contrato? Contrato {get; set; }

    }
    public enum StatusFaturaEnum
        {
            [Description("Pendente")]
            Pendente,
            
            [Description("Pago")]
            Pago,
            
            [Description("Atrasado")]
            Atrasado
        } 
}