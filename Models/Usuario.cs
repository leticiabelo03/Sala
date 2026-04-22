using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;

namespace Sala.Model{

    public class Usuario
    {
        [Column("id")]
        public int Id { get; set; }
        
        [Column("nome")]
        public required string Nome { get; set; }
        
        [Column("email")]
        public required string Email { get; set; }

        [Column("senhaHash")]
        public string? Senha {get; set; }

        [Column("perfil")]
        public PerfilUsuarioEnum PerfilUsuario {get; set; }

        [Column("ativo")]
        public bool Ativo {get; set; }


        [Column("dataCriacao")]
        public DateTime DataCriacao {get; set; }
    }
    public enum PerfilUsuarioEnum
        {
            [Description("Admin")]
            Admin,

            [Description("Tecnico")]
            Tecnico,

            [Description("Financeiro")]
            Financeiro
        }
}
