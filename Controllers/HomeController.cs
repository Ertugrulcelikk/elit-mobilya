using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using web_final_projesi.Models;
using web_final_projesi.Data;
using Microsoft.EntityFrameworkCore;
using web_final_projesi.Models.ViewModels;

namespace web_final_projesi.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
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

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Hakkimizda()
    {
        return View();
    }

    public IActionResult OturmaOdasi()
    {
        var products = _context.Products
            .Include(p => p.Category)
            .Where(p => p.Category.Name == "Oturma Odası" && p.IsActive)
            .OrderByDescending(p => p.CreatedAt)
            .ToList();

        return View(products);
    }

    public IActionResult TumUrunler()
    {
        var products = _context.Products
            .Include(p => p.Category)
            .Where(p => p.IsActive)
            .OrderByDescending(p => p.CreatedAt)
            .ToList();

        return View(products);
    }

    public IActionResult Iletisim()
    {
        return View();
    }

    public IActionResult CategoryProducts(int id)
    {
        var products = _context.Products
            .Include(p => p.Category)
            .Where(p => p.CategoryId == id && p.IsActive)
            .OrderByDescending(p => p.CreatedAt)
            .ToList();

        var category = _context.Categories.Find(id);
        ViewBag.CategoryName = category?.Name;

        return View(products);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
