using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Sala.Model
{
    public class Chamado
    {
        [Column("id")]
        public int Id { get; set; }
       
        [Column("titulo")]
        public required string Titulo { get; set; }
        
        [Column("descricao")]
        public required string Descricao { get; set; }
        
        [Column("status")]
        public StatusChamadoEnum Status { get; set; }
        
        [Column("prioridade")]
        public PrioridadeChamadoEnum PrioridadeChamado { get; set; }

        [Column("usuarioAberturaId")]
        public int UsuarioAberturaId { get; set; }
        
        [Column("clienteId")]
        public int ClienteId {get; set; }

        [Column("dataAbertura")]
        public DateTime DataAbetura { get; set; } = DateTime.Now;
        
        [Column("dataFechamento")]
        public DateTime? DataFechamento { get; set; }
       
        [Column("categoriaId")]
        public int CategoriaId { get; set; }

        // [Column("slaId")]
        // public int SlaId { get; set; }
        

        // Relacionamentos
        public CategoriaChamado? Categoria {get; set; }

        [ForeignKey("UsuarioAberturaId")] // 🔥 ESSA LINHA RESOLVE
        public Usuario? Usuario {get; set; }

        [ForeignKey("ClienteId")] // 🔥 ESSA LINHA RESOLVE
        public Cliente? Cliente {get; set; }

        // public Sla? Sla {get; set; }
    }
    

    public enum StatusChamadoEnum
    {
        [Description("Aberto")]
        Aberto,

        [Description("Em andamento")]
        Em_andamento,

        [Description("Fechado")]
        Fechado
    }

    public enum PrioridadeChamadoEnum
    {
        [Description("Baixa")]
        Baixa,
        
        [Description("Media")]
        Media,
        
        [Description("Alta")]
        Alta,
        
        [Description("Critica")]
        Critica
    }
    
}