using System.ComponentModel.DataAnnotations.Schema;

namespace Sala.Model
{
    [Table("categoria_chamado")]
    public class CategoriaChamado
    {

        [Column("id")]
        public int Id {get; set; }

        [Column("nome")]
        public required string Nome {get; set; }
    }
    
}