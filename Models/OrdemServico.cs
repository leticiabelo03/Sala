using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Sala.Model
{
    [Table("ordem_servico")]
    public class OrdemServico
    {

        [Column("id")]
        public int Id {get; set; }

        [Column("chamadoId")]
        public int ChamadoId {get; set; }

        [Column("status")]
        public StatusOrdemServicoEnum Status {get; set; } 


        [Column("dataCriacao")]
        public DateTime DataCriacao {get; set; } = DateTime.Now;
        
        [Column("dataConclusao")]
        public DateTime DataConclusao {get; set; }

        [Column("valorTotal")]
        public decimal ValorTotal { get; set; }
        

        // Relacionametos
        public Chamado? Chamado {get; set; }
    }
    public enum StatusOrdemServicoEnum
        {
            [Description("Pendente")]
            Pendente,

            [Description("Em andamento")]
            EmAndamento,

            [Description("Concluido")]
            Concluido
        }
}