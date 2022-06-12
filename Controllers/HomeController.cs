using System;
using System.Linq;
using BeachSys.Data;
using BeachSys.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeachSys.Controllers
{
    public class HomeController : Controller
    {
        private readonly BeachSysContext _context;
        public HomeController(BeachSysContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            int usuarioID = Int32.Parse(User.FindFirst("ID").Value);

            var usuario = _context.Usuarios.FirstOrDefault(u => u.ID == usuarioID);

            if (usuario is Admin)
            {
                return RedirectToAction("Index", "Admin");
            }
            return RedirectToAction("Index", "Usuario");
        }
    }
}