using System.ComponentModel.DataAnnotations;
using Sala.Model;

namespace Sala.ViewModel
{
    public class ChamadoCreateViewModel
    {
        [Required(ErrorMessage = "O campo é obrigatório")]
        public required string Titulo { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public required string Descricao { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public StatusChamadoEnum Status {get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public PrioridadeChamadoEnum PrioridadeChamado {get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public int CategoriaId {get; set; }

    }
}