using Sala.Model;

namespace Sala.ViewModel
{
    public class ChamadoListViewModel
    {
        public int Id { get; set; }

        public required string Titulo { get; set; }

        public required string Descricao { get; set; }

        public StatusChamadoEnum Status {get; set; }

        public PrioridadeChamadoEnum PrioridadeChamado {get; set; }

        public int UsuarioAberturaId {get; set; }

        public DateTime DataAbertura {get; set; }

        public DateTime DataFechamento {get; set; }

        public int CategoriaId {get; set; }

        public string? CategoriaNome { get; set; }

        public Usuario? Usuario {get; set; }
        public CategoriaChamado? CategoriaChamado {get; set; }

    }
}