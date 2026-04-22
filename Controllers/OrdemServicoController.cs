using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sala.Data;
using Sala.Model;
using Sala.ViewModel;

public class OrdemServicoController : Controller
{
    private readonly AppDbContext _context;

    public OrdemServicoController(AppDbContext context)
    {
        _context = context;
    }

    // 🔹 LISTAR
    public IActionResult Index()
    {
        var lista = _context.OrdemServico
            .Select(o => new OrdemServicoListViewModel
            {
                Id = o.Id,
                ChamadoId = o.ChamadoId,
                statusOrdemServico = o.Status,
                DataCriacao = o.DataCriacao,
                DataConclusao = o.DataConclusao,
                ValorTotal = o.ValorTotal 
            })
            .ToList();

        return View(lista);
    }

    // 🔹 DETALHE
    public IActionResult Detalhe(int id)
    {
        var os = _context.OrdemServico.FirstOrDefault(o => o.Id == id);

        if (os == null)
            return NotFound();

        return View(os);
    }

    // 🔹 CRIAR (GET)
    [HttpGet]
    public IActionResult Criar()
    {
        return View();
    }

    // 🔹 CRIAR (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Criar(OrdemServicoCreateViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var os = new OrdemServico
        {
            ChamadoId = model.ChamadoId,
            Status = model.statusOrdemServico,
            DataCriacao = DateTime.Now
        };

        _context.OrdemServico.Add(os);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    // 🔹 EDITAR (GET)
    [HttpGet]
    public IActionResult Editar(int id)
    {
        var os = _context.OrdemServico.Find(id);

        if (os == null)
            return NotFound();

        var vm = new OrdemServicoEditViewModel
        {
            Id = os.Id,
            DataConclusao = os.DataConclusao,
            statusOrdemServico = os.Status,
            ValorTotal = os.ValorTotal
        };

        return View(vm);
    }

    // 🔹 EDITAR (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Editar(OrdemServicoEditViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var os = _context.OrdemServico.Find(model.Id);

        if (os == null)
            return NotFound();

        os.Status = model.statusOrdemServico;
        os.ValorTotal = model.ValorTotal;

        if (model.statusOrdemServico == StatusOrdemServicoEnum.Concluido)
            os.DataConclusao = DateTime.Now;
        else
            os.DataConclusao = model.DataConclusao;

        _context.SaveChanges();

        return RedirectToAction("Index");
    }

    // 🔹 EXCLUIR (GET - confirmação)
    [HttpGet]
    public IActionResult Deletar(int id)
    {
        var os = _context.OrdemServico.Find(id);

        if (os == null)
            return NotFound();

        return View(os);
    }

    // 🔹 EXCLUIR (POST)
    [HttpPost, ActionName("Deletar")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletarConfirmado(int id)
    {
        var os = _context.OrdemServico.Find(id);

        if (os == null)
            return NotFound();

        _context.OrdemServico.Remove(os);
        _context.SaveChanges();

        return RedirectToAction("Index");
    }
}