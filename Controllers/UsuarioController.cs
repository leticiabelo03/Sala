using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Sala.Data;
using Sala.Model;
using Sala.ViewModel;

namespace Sala.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly AppDbContext _context;

        public UsuarioController(AppDbContext context)
        {
            _context = context;
        }

        // 🔹 LISTAR
        [HttpGet]
        public IActionResult Index()
        {
            var usuarios = _context.Usuario
                .Select(u => new UsuarioListViewModel
                {
                    Id = u.Id,
                    Nome = u.Nome,
                    Email = u.Email,
                    PerfilUsuario = u.PerfilUsuario
                })
                .ToList();

            return View(usuarios);
        }

        // 🔹 DETALHE
        [HttpGet]
        public IActionResult Detalhe(int id)
        {
            var usuario = _context.Usuario.Find(id);

            if (usuario == null)
                return NotFound();

            return View(usuario);
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
        public IActionResult Criar(UsuarioCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            // var hasher = new PasswordHasher<Usuario>();

            var usuario = new Usuario
            {
                Nome = model.Nome,
                Email = model.Email,
                // Senha = model.Senha,
                PerfilUsuario = model.PerfilUsuario,
                DataCriacao = DateTime.Now,
                Ativo = true,
                Senha = ""
            };

            var hasher = new PasswordHasher<Usuario>();
            usuario.Senha = hasher.HashPassword(usuario, model.Senha!);

            try
            {
                _context.Usuario.Add(usuario);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Erro ao criar usuário.");
                return View(model);
            }
        }

        // 🔹 EDITAR (GET)
        [HttpGet]
        public IActionResult Editar(int id)
        {

            var usuario = _context.Usuario.Find(id);

            if (usuario == null)
                return NotFound();

            var model = new UsuarioEditViewModel
            {
                Id = usuario.Id,
                // Senha = usuario.Senha,
                Nome = usuario.Nome,
                Email = usuario.Email
                // Senha normalmente NÃO volta para edição direta
            };

            return View(model);
        }

        // 🔹 EDITAR (POST)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Editar(int id, UsuarioEditViewModel model)
        {
            if (id != model.Id)
                return BadRequest();

            if (!ModelState.IsValid)
                return View(model);

            var usuario = _context.Usuario.Find(id);

            if (usuario == null)
                return NotFound();

            usuario.Nome = model.Nome;
            usuario.Email = model.Email;
            // usuario.Senha = model.Senha;

            if (!string.IsNullOrWhiteSpace(model.Senha)) // Mudamos para IsNullOrWhiteSpace
            {
                var hasher = new PasswordHasher<Usuario>();
                // O '!' diz ao C#: "Eu garanto que não é nulo porque acabei de testar acima"
                usuario.Senha = hasher.HashPassword(usuario, model.Senha!);
            }

            try
            {
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Erro ao atualizar usuário.");
                return View(model);
            }
        }

        // 🔹 DELETAR (GET - confirmação)
        [HttpGet]
        public IActionResult Deletar(int id)
        {
            var usuario = _context.Usuario.Find(id);

            if (usuario == null)
                return NotFound();

            return View(usuario);
        }

        // 🔹 DELETAR (POST)
        [HttpPost]
        [ActionName("Deletar")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletarConfirmado(int id)
        {
            var usuario = _context.Usuario.Find(id);

            if (usuario == null)
                return NotFound();

            try
            {
                _context.Usuario.Remove(usuario);
                _context.SaveChanges();

                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Erro ao deletar usuário.");
                return View(usuario);
            }
        }
    }
}
