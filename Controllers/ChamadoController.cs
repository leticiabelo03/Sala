using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Sala.Data;
using Sala.Model;
using Sala.ViewModel;
using Microsoft.AspNetCore.Mvc.Rendering;


public class ChamadoController : Controller
{
    private readonly AppDbContext _context;

    public ChamadoController(AppDbContext context)
    {
        _context = context;
    }

    // LISTAR
    public async Task<IActionResult> Index()
    {
        var chamados = await _context.Chamado
            .Include(c => c.Categoria)
            .AsNoTracking() // 🔥 melhora performance
            .Select(c => new ChamadoListViewModel
            {
                Id = c.Id,
                Titulo = c.Titulo,
                Descricao = c.Descricao,
                Status = c.Status,
                PrioridadeChamado = c.PrioridadeChamado,
                DataAbertura = c.DataAbetura,
                CategoriaId = c.CategoriaId,
                CategoriaNome = c.Categoria!.Nome
            }).ToListAsync();

        return View(chamados);
    }

    // CRIAR (GET)
    public IActionResult Criar()
    {
        CarregarCategoriasEClientes();
        return View();
    }

    // CRIAR (POST)
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Criar(ChamadoCreateViewModel model)
    {
        if (!ModelState.IsValid)
        {
            CarregarCategoriasEClientes();
            return View(model);
        }

        var chamado = new Chamado
        {
            Titulo = model.Titulo,
            Descricao = model.Descricao,
            Status = model.Status,
            PrioridadeChamado = model.PrioridadeChamado,
            CategoriaId = model.CategoriaId,
            DataAbetura = DateTime.Now,
            UsuarioAberturaId = 1,
            ClienteId = model.ClienteId
        };

        _context.Chamado.Add(chamado);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public async Task<IActionResult> Editar(int id)
    {
        var chamado = await _context.Chamado.FindAsync(id);

        if (chamado == null)
            return NotFound();

        var model = new ChamadoEditViewModel
        {
            Id = chamado.Id,
            Titulo = chamado.Titulo,
            Descricao = chamado.Descricao,
            Status = chamado.Status,
            PrioridadeChamado = chamado.PrioridadeChamado,
            CategoriaId = chamado.CategoriaId,
            ClienteId = chamado.ClienteId
        };

        CarregarCategoriasEClientes();

        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Editar(ChamadoEditViewModel model)
    {
        if (!ModelState.IsValid)
        {
            CarregarCategoriasEClientes();
            return View(model);
        }

        var chamado = await _context.Chamado.FindAsync(model.Id);

        if (chamado == null)
            return NotFound();

        chamado.Titulo = model.Titulo;
        chamado.Descricao = model.Descricao;
        chamado.Status = model.Status;
        chamado.PrioridadeChamado = model.PrioridadeChamado;
        chamado.CategoriaId = model.CategoriaId;
        chamado.ClienteId = model.ClienteId;

        if (chamado.Status == StatusChamadoEnum.Fechado)
        {
            chamado.DataFechamento = DateTime.Now;

            var existeOS = await _context.OrdemServico
                .AnyAsync(o => o.ChamadoId == chamado.Id);

            if (!existeOS)
            {
                var novaOS = new OrdemServico
                {
                    ChamadoId = chamado.Id,
                    Status = StatusOrdemServicoEnum.Pendente,
                    DataCriacao = DateTime.Now,
                    ValorTotal = 0
                };

                _context.OrdemServico.Add(novaOS);
            }
        }

        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Deletar(int id)
    {
        var chamado = await _context.Chamado
            .FirstOrDefaultAsync(c => c.Id == id);

        if (chamado == null)
            return NotFound();

        return View(chamado);
    }

    [HttpPost, ActionName("Deletar")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeletarConfirmado(int id)
    {
        var chamado = await _context.Chamado.FindAsync(id);

        if (chamado != null)
        {
            _context.Chamado.Remove(chamado);
            await _context.SaveChangesAsync();
        }

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Detalhe(int id)
    {
        var chamado = await _context.Chamado
            .Include(c => c.Categoria)
            .Include(c => c.Usuario)
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Id == id);

        if (chamado == null)
            return NotFound();

        var model = new ChamadoDetalheViewModel
        {
            Id = chamado.Id,
            Titulo = chamado.Titulo,
            Descricao = chamado.Descricao,
            Status = chamado.Status,
            PrioridadeChamado = chamado.PrioridadeChamado,
            DataAbertura = chamado.DataAbetura,
            DataFechamento = chamado.DataFechamento,
            CategoriaNome = chamado.Categoria?.Nome ?? "Sem categoria",
            UsuarioAberturaNome = chamado.Usuario?.Nome ?? "Sistema"
        };

        return View(model);
    }

    // 🔥 MÉTODO AUXILIAR (melhora organização)
    private void CarregarCategorias()
    {
        ViewBag.Categorias = new SelectList(
            _context.Set<CategoriaChamado>(),
            "Id",
            "Nome"
        );
    }
    private void CarregarCategoriasEClientes()
    {
        ViewBag.Categorias = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(
            _context.Set<CategoriaChamado>(),
            "Id",
            "Nome"
        );

        ViewBag.Clientes = new Microsoft.AspNetCore.Mvc.Rendering.SelectList(
            _context.Cliente.ToList(),
            "Id",
            "Nome"
        );
    }
}