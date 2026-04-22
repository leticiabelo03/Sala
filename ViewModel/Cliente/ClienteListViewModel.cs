using System.ComponentModel.DataAnnotations;
using Sala.Model;

namespace Sala.ViewModel
{
    public class ClienteListViewModel
    {

        public int Id {get; set; }

        public required string Nome {get; set; }

        public required string Email {get; set; }

        public required string Telefone {get; set; }
    }
}