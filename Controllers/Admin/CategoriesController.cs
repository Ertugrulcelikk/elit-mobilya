using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_final_projesi.Data;
using web_final_projesi.Models;

namespace web_final_projesi.Controllers.Admin
{
    public class CategoriesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CategoriesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetString("AdminId") == null)
                return RedirectToAction("Login", "Admin");

            var categories = _context.Categories
                .OrderByDescending(c => c.Id)
                .ToList();
            return View("~/Views/Admin/Categories/Index.cshtml", categories);
        }

        public IActionResult Create()
        {
            return View("~/Views/Admin/Categories/Create.cshtml");
        }

        [HttpPost]
        public IActionResult Create(Category category)
        {
            if (ModelState.IsValid)
            {
                category.IsActive = true;
                _context.Categories.Add(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/Admin/Categories/Create.cshtml", category);
        }

        public IActionResult Edit(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
                return NotFound();

            return View("~/Views/Admin/Categories/Edit.cshtml", category);
        }

        [HttpPost]
        public IActionResult Edit(int id, Category category)
        {
            if (id != category.Id)
                return NotFound();

            if (ModelState.IsValid)
            {
                _context.Update(category);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View("~/Views/Admin/Categories/Edit.cshtml", category);
        }

        public IActionResult Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }
    }
} 