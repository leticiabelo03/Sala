using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.SignalR;
using System.ComponentModel;

namespace Sala.Model
{
    public class LogAuditoria
    {

        [Column("id")]
        public int id {get; set; }

        [Column("usuarioId")]
        public int UsuarioId {get; set; }

        [Column("acao")]
        public AcaoLogAuditoriaEnum Acao {get; set; }

        [Column("entidade")]
        public string? Entidade {get; set; }

        [Column("entidadeId")]
        public int EntidadeId {get; set; }

        [Column("dataHora")]
        public DateTime DataHora {get; set; }

        [Column("dadosAntes")]
        public required string DadosAntes {get; set; }

        [Column("dadosDepois")]
        public required string DadosDepois {get; set; }


        // Relacionamentos
        public Usuario? Usuario {get; set; }

        public enum AcaoLogAuditoriaEnum
        {
            [Description("CREATE")]
            Create,

            [Description("UPDATE")]
            Update,

            [Description("DELETE")]
            Delete
        }
    }
}