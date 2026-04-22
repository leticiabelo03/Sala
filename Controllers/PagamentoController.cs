using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sala.Data;
using Sala.Model;
using Sala.ViewModel;

[Authorize(Roles = "Financeiro,Admin")]
public class PagamentoController : Controller
{
    private readonly AppDbContext _context;

    public PagamentoController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult Criar(int faturaId)
    {
        var fatura = _context.Fatura.FirstOrDefault(f => f.Id == faturaId);

        if (fatura == null)
            return NotFound();

        var vm = new PagamentoCreateViewModel
        {
            FaturaId = fatura.Id,
            ValorFatura = fatura.ValorTotal,
            ValorPago = fatura.ValorTotal,
            DataPagamento = DateTime.Now
        };

        return View(vm);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Criar(PagamentoCreateViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var fatura = _context.Fatura.FirstOrDefault(f => f.Id == model.FaturaId);

        if (fatura == null)
            return NotFound();

        var jaPago = _context.Pagamento.Any(p => p.FaturaId == model.FaturaId);
        if (jaPago)
        {
            ModelState.AddModelError("", "Esta fatura já possui pagamento registrado.");
            return View(model);
        }

        var pagamento = new Pagamento
        {
            FaturaId = model.FaturaId,
            DataPagamento = model.DataPagamento,
            ValorPago = model.ValorPago,
            Metodo = model.Metodo
        };

        _context.Pagamento.Add(pagamento);

        // Marca a fatura como paga
        fatura.Status = StatusFaturaEnum.Pago;

        _context.SaveChanges();

        return RedirectToAction("Faturas", "Financeiro");
    }
}