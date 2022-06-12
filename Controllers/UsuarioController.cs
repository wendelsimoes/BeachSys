using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BeachSys.Data;
using BeachSys.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BeachSys.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly BeachSysContext _context;

        public UsuarioController(BeachSysContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastrar([Bind("Nome,CPF,Email")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                var usuarioExiste = _context.Usuarios.FirstOrDefault(u => u.CPF == usuario.CPF);

                if (usuarioExiste != null)
                {
                    ModelState.AddModelError("CPF", "Já existe um usuário com este CPF");
                    return View(usuario);
                }

                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction("Login", "Usuario");
            }
            return View(usuario);
        }

        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(string CPF)
        {
            var usuarioExiste = _context.Usuarios.FirstOrDefault(u => u.CPF == CPF);
            
            if (CPF == null)
            {
                ModelState.AddModelError("CPF", "Este campo é obrigatorio");
                return View(usuarioExiste);
            }

            if (usuarioExiste == null)
            {
                ModelState.AddModelError("CPF", "Usuário não encontrado");
                return View(usuarioExiste);
            }
            
            List<Claim> direitosAcesso = new List<Claim>{
                new Claim("ID", usuarioExiste.ID.ToString())
            };
            
            var identidade = new ClaimsIdentity(direitosAcesso, "Identity.Login");
            var usuarioPrincipal = new ClaimsPrincipal(new[] { identidade });

            await HttpContext.SignInAsync(usuarioPrincipal, new AuthenticationProperties
            {
                IsPersistent = false,
                ExpiresUtc = DateTime.Now.AddHours(1)
            });
            
            if (CPF == "admin")
            {
                return RedirectToAction("Index", "Admin");
            }

            return RedirectToAction("Index", "Usuario");
        }

        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Sair()
        {
            if (User.Identity.IsAuthenticated)
            {
                await HttpContext.SignOutAsync();
            }

            return RedirectToAction("Login", "Usuario");
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
