using System.ComponentModel.DataAnnotations.Schema;

namespace SalaApp.Models;

public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
