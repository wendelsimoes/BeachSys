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
    public class ArmarioController : Controller
    {
        private readonly BeachSysContext _context;

        public ArmarioController(BeachSysContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Criar([Bind("Nome,PontoX,PontoY")] Armario armario)
        {
            if (ModelState.IsValid)
            {
                var admin = _context.Admins.FirstOrDefault(a => a.CPF == "admin");
                armario.Admin = admin;
                _context.Add(armario);
                _context.SaveChanges();
                return RedirectToAction("Index", new {cpf = "admin"});
            }

            return View(armario);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Index()
        {
            var armarios = _context.Armarios.ToList();
            return View(armarios);
        }
    }
}
