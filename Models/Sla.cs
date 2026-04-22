using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Sala.Model
{
    public class Sla
    {
        [Column("id")]
        public int Id {get; set; }
        
        [Column("nome")]
        public string? Nome {get; set; }
       
        [Column("tempoRespostaHoras")]
        public int TempoRespostaHoras {get; set; }
        
        [Column("tempoResolucaoHoras")]
        public int TempoResolucaoHoras {get; set; }
    }
}