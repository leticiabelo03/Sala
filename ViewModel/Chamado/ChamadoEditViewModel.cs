using System.ComponentModel.DataAnnotations;
using Sala.Model;


namespace Sala.ViewModel
{
    public class ChamadoEditViewModel
    {

        [Required(ErrorMessage = "O campo é obrigatório")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public required string Titulo { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public required string Descricao { get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public StatusChamadoEnum Status {get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public PrioridadeChamadoEnum PrioridadeChamado {get; set; }

        public DateTime DataFechamento {get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public int CategoriaId {get; set; }

        [Required(ErrorMessage = "O campo é obrigatório")]
        public int ClienteId { get; set; }

    }
}