using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_final_projesi.Data;
using web_final_projesi.Models;

namespace web_final_projesi.Controllers
{
    [Route("Admin/[controller]")]
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("")]
        [Route("Index")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminId") == null)
                return RedirectToAction("Login", "Admin");

            var products = _context.Products
                .Include(p => p.Category)
                .OrderByDescending(p => p.CreatedAt)
                .ToList();
            return View("~/Views/Admin/Products/Index.cshtml", products);
        }

        [HttpGet]
        [Route("Create")]
        public IActionResult Create()
        {
            ViewBag.Categories = _context.Categories.Where(c => c.IsActive).ToList();
            return View("~/Views/Admin/Products/Create.cshtml");
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(Product product)
        {
            if (ModelState.IsValid)
            {
                product.CreatedAt = DateTime.Now;
                product.IsActive = true;
                _context.Products.Add(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = _context.Categories.Where(c => c.IsActive).ToList();
            return View("~/Views/Admin/Products/Create.cshtml", product);
        }

        [HttpGet]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
                return NotFound();

            ViewBag.Categories = _context.Categories.Where(c => c.IsActive).ToList();
            return View("~/Views/Admin/Products/Edit.cshtml", product);
        }

        [HttpPost]
        [Route("Edit/{id}")]
        public IActionResult Edit(int id, Product product)
        {
            if (id != product.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(product);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = _context.Categories.Where(c => c.IsActive).ToList();
            return View("~/Views/Admin/Products/Edit.cshtml", product);
        }

        [HttpGet]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
} 