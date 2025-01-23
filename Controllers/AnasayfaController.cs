using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using web_final_projesi.Models;
using web_final_projesi.Data;
using Microsoft.EntityFrameworkCore;
using web_final_projesi.Models.ViewModels;

namespace web_final_projesi.Controllers
{
    public class AnasayfaController : Controller
    {
        private readonly ILogger<AnasayfaController> _logger;
        private readonly ApplicationDbContext _context;

        public AnasayfaController(ILogger<AnasayfaController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Anasayfa()
        {
            var viewModel = new HomeViewModel
            {
                Categories = _context.Categories.Where(c => c.IsActive).ToList(),
                FeaturedProducts = _context.Products
                    .Include(p => p.Category)
                    .Where(p => p.IsActive)
                    .OrderByDescending(p => p.CreatedAt)
                    .Take(6)
                    .ToList()
            };

            return View(viewModel);
        }

        
        public IActionResult Gizlilik()
        {
            return View();
        }

        public IActionResult Hakkimizda()
        {
            return View();
        }

        public IActionResult Iletisim()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Hata()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
} 