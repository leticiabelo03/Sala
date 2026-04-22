using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Sala.Data;
using Sala.Model;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Sala.ViewModel;

public class AuthController : Controller
{
    private readonly AppDbContext _context;

    public AuthController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public IActionResult LoginLocal()
    {
        return View();
    }

    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync(
            CookieAuthenticationDefaults.AuthenticationScheme
        );

        return RedirectToAction("LoginLocal", "Auth");
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LoginLocal(LoginViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        var usuario = _context.Usuario
            .FirstOrDefault(u => u.Email == model.Email && u.Ativo);

        if (usuario == null)
        {
            ModelState.AddModelError("", "Usuário ou senha inválidos");
            return View(model);
        }

        var hasher = new PasswordHasher<Usuario>();

        var resultado = hasher.VerifyHashedPassword(
            usuario,
            usuario.Senha,
            model.Senha
        );

        if (resultado == PasswordVerificationResult.Failed)
        {
            ModelState.AddModelError("", "Usuário ou senha inválidos");
            return View(model);
        }

        // 🔐 Claims (AGORA COM ROLE)
        var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, usuario.Nome),
        new Claim(ClaimTypes.Email, usuario.Email),
        new Claim("UserId", usuario.Id.ToString()),

        // 🔥 ESSA LINHA MUDA TUDO
        new Claim(ClaimTypes.Role, usuario.PerfilUsuario.ToString())
    };

        var identity = new ClaimsIdentity(
            claims,
            CookieAuthenticationDefaults.AuthenticationScheme
        );

        var principal = new ClaimsPrincipal(identity);

        // 🔥 FAZER LOGIN DE VERDADE
        await HttpContext.SignInAsync(
            CookieAuthenticationDefaults.AuthenticationScheme,
            principal
        );

        // 🔀 REDIRECIONAMENTO INTELIGENTE
        switch (usuario.PerfilUsuario)
        {
            case PerfilUsuarioEnum.Admin:
                return RedirectToAction("Index", "Admin");

            case PerfilUsuarioEnum.Financeiro:
                return RedirectToAction("Dashboard", "Financeiro");

            case PerfilUsuarioEnum.Tecnico:
                return RedirectToAction("Index", "Tecnico");

            default:
                return RedirectToAction("Index", "Home");
        }
    }
}