using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sala.Data;
using Sala.Model;
using Sala.ViewModel;

[Authorize(Roles = "Tecnico")]
public class TecnicoController : Controller
{
    private readonly AppDbContext _context;

    public TecnicoController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var vm = new TecnicoDashboardViewModel
        {
            TotalChamados = _context.Chamado.Count(),
            TotalChamadosAbertos = _context.Chamado.Count(c => c.DataFechamento == null),
            TotalOrdensServico = _context.OrdemServico.Count(),
            TotalOrdensConcluidas = _context.OrdemServico.Count(o => o.Status == StatusOrdemServicoEnum.Concluido)
        };

        return View(vm);
    }
}