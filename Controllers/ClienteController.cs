using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sala.Data;
using Sala.Model;

[Authorize(Roles = "Admin,Tecnico")]
public class ClienteController : Controller
{
    private readonly AppDbContext _context;

    public ClienteController(AppDbContext context)
    {
        _context = context;
    }

    public IActionResult Index()
    {
        var lista = _context.Cliente.ToList();
        return View(lista);
    }

    [HttpGet]
    public IActionResult Criar()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Criar(Cliente model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var emailJaExiste = _context.Cliente.Any(c => c.Email == model.Email);
        if (emailJaExiste)
        {
            ModelState.AddModelError("Email", "Já existe um cliente com esse e-mail.");
            return View(model);
        }

        _context.Cliente.Add(model);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult Editar(int id)
    {
        var cliente = _context.Cliente.Find(id);

        if (cliente == null)
            return NotFound();

        return View(cliente);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Editar(Cliente model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var cliente = _context.Cliente.Find(model.Id);

        if (cliente == null)
            return NotFound();

        var emailJaExiste = _context.Cliente.Any(c => c.Email == model.Email && c.Id != model.Id);
        if (emailJaExiste)
        {
            ModelState.AddModelError("Email", "Já existe um cliente com esse e-mail.");
            return View(model);
        }

        cliente.Nome = model.Nome;
        cliente.Email = model.Email;
        cliente.Telefone = model.Telefone;

        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }

    public IActionResult Detalhe(int id)
    {
        var cliente = _context.Cliente.FirstOrDefault(c => c.Id == id);

        if (cliente == null)
            return NotFound();

        return View(cliente);
    }

    [HttpGet]
    public IActionResult Deletar(int id)
    {
        var cliente = _context.Cliente.Find(id);

        if (cliente == null)
            return NotFound();

        return View(cliente);
    }

    [HttpPost, ActionName("Deletar")]
    [ValidateAntiForgeryToken]
    public IActionResult DeletarConfirmado(int id)
    {
        var cliente = _context.Cliente.Find(id);

        if (cliente == null)
            return NotFound();

        _context.Cliente.Remove(cliente);
        _context.SaveChanges();

        return RedirectToAction(nameof(Index));
    }
}