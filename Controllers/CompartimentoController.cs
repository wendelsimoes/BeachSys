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
                armario.Compartimentos.Add(compartimento);
                _context.Add(compartimento);
                _context.SaveChanges();
                return RedirectToAction("Index", "Armario");
            }

            return View(compartimento);
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
    }
}
