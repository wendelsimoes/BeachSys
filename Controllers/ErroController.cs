using System;
using System.Linq;
using BeachSys.Data;
using BeachSys.Models;
using Microsoft.AspNetCore.Mvc;

namespace BeachSys.Controllers
{
    public class ErroController : Controller
    {
        public ErroController()
        {
        }
        
        public IActionResult Index()
        {
            return View();
        }
    }
}