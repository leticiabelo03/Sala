using System.ComponentModel.DataAnnotations.Schema;

namespace Sala.Model
{
    public class ItemOrdemServico
    {

        [Column("id")]
        public int Id {get; set; }

        [Column("ordemServicoId")]
        public  int OrdemServicoId {get; set; }

        [Column("descricao")]
        public required string Descricao {get; set; }

        [Column("quantidade")]
        public int Quantidade {get; set; }

        [Column("valorUnitario")]
        public decimal ValorUnitario {get; set;}

        // Relacionamentos
        public OrdemServico? OrdemServico {get; set; }
    }
}