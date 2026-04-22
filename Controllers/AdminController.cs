using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sala.Data;
using Sala.Model;
using Sala.ViewModel;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    private readonly AppDbContext _context;

    public AdminController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var vm = new AdminDashboardViewModel
        {
            TotalUsuarios = _context.Usuario.Count(),
            TotalUsuariosAtivos = _context.Usuario.Count(u => u.Ativo),

            TotalChamados = _context.Chamado.Count(),
            ChamadosAbertos = _context.Chamado.Count(c => c.Status == StatusChamadoEnum.Aberto),
            ChamadosFechados = _context.Chamado.Count(c => c.Status == StatusChamadoEnum.Fechado),

            TotalOrdensServico = _context.OrdemServico.Count(),
            OsPendentes = _context.OrdemServico.Count(o => o.Status == StatusOrdemServicoEnum.Pendente),
            OsConcluidas = _context.OrdemServico.Count(o => o.Status == StatusOrdemServicoEnum.Concluido),

            TotalFaturas = _context.Fatura.Count(),
            FaturasPendentes = _context.Fatura.Count(f => f.Status == StatusFaturaEnum.Pendente),
            FaturasPagas = _context.Fatura.Count(f => f.Status == StatusFaturaEnum.Pago),

            FaturamentoTotal = _context.Fatura
                .Where(f => f.Status == StatusFaturaEnum.Pago)
                .Sum(f => (decimal?)f.ValorTotal) ?? 0,

            UltimosChamados = _context.Chamado
                .OrderByDescending(c => c.DataAbetura)
                .Take(5)
                .ToList(),

            UltimasFaturas = _context.Fatura
                .OrderByDescending(f => f.DataGeracao)
                .Take(5)
                .ToList()
        };

        return View(vm);
    }
}