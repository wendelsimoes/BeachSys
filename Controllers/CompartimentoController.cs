using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BeachSys.Data;
using BeachSys.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BeachSys.Controllers
{
    public class CompartimentoController : Controller
    {
        private readonly BeachSysContext _context;

        public CompartimentoController(BeachSysContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Criar([Bind("Comprimento,Largura,ArmarioID")] Compartimento compartimento)
        {
            if (ModelState.IsValid)
            {
                var armario = _context.Armarios.FirstOrDefault(a => a.ID == compartimento.ArmarioID);
                compartimento.Armario = armario;
                _context.Add(compartimento);
                _context.SaveChanges();
                return RedirectToAction("Index", "Armario");
            }

            return View(compartimento);
        }

        [HttpPost]
        public IActionResult Escolher(int numero)
        {
            var compartimento = _context.Compartimentos.Find(numero);
            
            if (compartimento == null)
            {
                return NotFound();
            }

            if (compartimento.Disponivel)
            {
                int usuarioID = Int32.Parse(User.FindFirst("ID").Value);
                var usuario = _context.Usuarios
                .Include(u => u.Compartimento)
                .FirstOrDefault(u => u.ID == usuarioID);

                if (usuario.Compartimento != null)
                {
                    TempData["erro"]="Você não pode alocar mais de um compartimento ao mesmo tempo";
                    return RedirectToAction("Index", "Erro");
                }

                compartimento.Usuario = usuario;
                compartimento.Disponivel = false;
                _context.SaveChanges();
                return RedirectToAction("Index", "Compartimento");
            }
            return BadRequest();
        }

        public IActionResult Criar(int armarioID)
        {
            ViewBag.ArmarioID = armarioID;
            return View();
        }

        public IActionResult Index(int ArmarioID)
        {
            var compartimentos = _context.Compartimentos.Where(c => c.ArmarioID == ArmarioID).ToList();

            return View(compartimentos);
        }

        public IActionResult MeuCompartimento()
        {
            int usuarioID = Int32.Parse(User.FindFirst("ID").Value);

            var meuCompartimento = _context
            .Compartimentos
            .Include(c => c.Armario)
            .FirstOrDefault(c => c.UsuarioID == usuarioID);

            return View(meuCompartimento);
        }

        public IActionResult Desalocar(int compartimentoNumero)
        {
            var compartimento = _context
            .Compartimentos
            .Include(c => c.Usuario)
            .FirstOrDefault(c => c.Numero == compartimentoNumero);

            compartimento.Usuario = null;
            compartimento.UsuarioID = null;
            compartimento.Disponivel = true;

            _context.SaveChanges();

            return RedirectToAction("MeuCompartimento", "Compartimento");
        }
    }
}
