using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.SignalR;

namespace Sala.Model
{
    public class LogAcesso
    {

        [Column("id")]
        public int id {get; set; }

        [Column("usuarioId")]
        public int UsuarioId {get; set; }

        [Column("dataLogin")]
        public DateTime DataLogin {get; set; }

        [Column("ip")]
        public string? Ip {get; set; }

        [Column("sucesso")]
        public bool Sucesso {get; set; }

        // Relacionamentos
        public Usuario? Usuario {get; set; }
    }
}