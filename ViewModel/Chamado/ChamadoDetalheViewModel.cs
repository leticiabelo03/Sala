using System;
using Sala.Model;

namespace Sala.ViewModel
{
    public class ChamadoDetalheViewModel
    {
        public int Id { get; set; }

        public string Titulo { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;

        public StatusChamadoEnum Status { get; set; }

        public PrioridadeChamadoEnum PrioridadeChamado { get; set; }

        public DateTime DataAbertura { get; set; }

        public DateTime? DataFechamento { get; set; }

        public string CategoriaNome { get; set; } = string.Empty;

        public string UsuarioAberturaNome { get; set; } = string.Empty;
    }
}