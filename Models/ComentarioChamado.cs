using System.ComponentModel.DataAnnotations.Schema;

namespace Sala.Model
{
    public class ComentarioChamado
    {

        [Column("id")]
        public int Id {get; set; }

        [Column("chamadoId")]
        public int ChamadoId {get; set; }

        [Column("usuarioId")]
        public int UsuarioId {get; set; }

        [Column("mensagem")]
        public required string Mensagem {get; set; }

        [Column("dataEnvio")]
        public DateTime DataEnvio {get; set; }

        // Relacionametos 
        public Chamado? Chamado {get; set; }
        public Usuario? Usuario {get; set; }
    }
}