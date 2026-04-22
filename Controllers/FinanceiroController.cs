using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sala.Data;
using Sala.Model;
using Sala.ViewModel;

[Authorize(Roles = "Financeiro")]
public class FinanceiroController : Controller
{
    private readonly AppDbContext _context;

    public FinanceiroController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Dashboard()
    {
        var pendentes = _context.OrdemServico
            .Where(o => o.Status == StatusOrdemServicoEnum.Concluido)
            .ToList()
            .Where(o => !_context.Fatura.Any(f => f.OrdemServicoId == o.Id))
            .ToList();

        var vm = new FinanceiroDashboardViewModel
        {
            TotalPendentes = pendentes.Count,
            ValorPendente = pendentes.Sum(x => x.ValorTotal),

            TotalFaturas = _context.Fatura.Count(),
            ValorFaturado = _context.Fatura.Sum(x => (decimal?)x.ValorTotal) ?? 0,

            Pendentes = pendentes
        };

        return View(vm);
    }

    [HttpPost]
    public IActionResult Faturar(int id)
    {
        var os = _context.OrdemServico.FirstOrDefault(o => o.Id == id);

        if (os == null)
            return NotFound();

        var fatura = new Fatura
        {
            OrdemServicoId = os.Id,
            ValorTotal = os.ValorTotal,
            Status = StatusFaturaEnum.Pendente,
            DataGeracao = DateTime.Now,
            DataVencimento = DateTime.Now.AddDays(7)
        };

        _context.Fatura.Add(fatura);
        _context.SaveChanges();

        return RedirectToAction("Dashboard");
    }

    public IActionResult Faturas()
    {
        var lista = _context.Fatura
            .OrderByDescending(f => f.DataGeracao)
            .ToList();

        return View(lista);
    }
}