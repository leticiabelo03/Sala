using System.ComponentModel.DataAnnotations.Schema;

namespace Sala.Model
{
    public class Cliente
    {
        [Column("id")]
        public int Id {get; set; }

        [Column("nome")]
        public required string Nome {get; set; }

        [Column("email")]
        public required string Email {get; set; }

        [Column("telefone")]
        public required string Telefone {get; set; }
    }
}