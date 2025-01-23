using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using web_final_projesi.Data;
using web_final_projesi.Models;

namespace web_final_projesi.Controllers
{
    public class CartController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CartController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var sessionId = HttpContext.Session.Id;
            var cartItems = _context.CartItems
                .Include(c => c.Product)
                .ThenInclude(p => p.Category)
                .Where(c => c.SessionId == sessionId)
                .OrderByDescending(c => c.CreatedAt)
                .ToList();

            return View(cartItems);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, int quantity = 1)
        {
            var sessionId = HttpContext.Session.Id;
            var cartItem = _context.CartItems
                .FirstOrDefault(c => c.SessionId == sessionId && c.ProductId == productId);

            if (cartItem == null)
            {
                cartItem = new CartItem
                {
                    SessionId = sessionId,
                    ProductId = productId,
                    Quantity = quantity,
                    CreatedAt = DateTime.Now
                };
                _context.CartItems.Add(cartItem);
            }
            else
            {
                cartItem.Quantity += quantity;
            }

            _context.SaveChanges();

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int id, int quantity)
        {
            var cartItem = _context.CartItems.Find(id);
            if (cartItem != null)
            {
                cartItem.Quantity = quantity;
                _context.SaveChanges();
            }

            return Json(new { success = true });
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int id)
        {
            var cartItem = _context.CartItems.Find(id);
            if (cartItem != null)
            {
                _context.CartItems.Remove(cartItem);
                _context.SaveChanges();
            }

            return Json(new { success = true });
        }
    }
} 