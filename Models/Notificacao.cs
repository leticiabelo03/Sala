using System.ComponentModel.DataAnnotations.Schema;

namespace Sala.Model
{
    public class Notificacao
    {

        [Column("id")]
        public int Id {get; set; }

        [Column("usuarioId")]
        public int UsuarioId {get; set; }

        [Column("titulo")]
        public required string Titulo {get; set; }

        [Column("mensagem")]
        public required string Mensagem {get; set; }

        [Column("lida")]
        public bool Lida {get; set; }

        [Column("dataEnvio")]
        public DateTime DataEnvio {get; set; }

        // Relacionamentos
        public Usuario? Usuario {get; set; }

    }
}