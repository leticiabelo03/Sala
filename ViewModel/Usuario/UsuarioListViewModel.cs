using Sala.Model;

namespace Sala.ViewModel
{
    public class UsuarioListViewModel
    {
        public int Id { get; set; }

        public required string Nome { get; set; }

        public required string Email { get; set; }

        public PerfilUsuarioEnum PerfilUsuario {get; set; }

    }
}