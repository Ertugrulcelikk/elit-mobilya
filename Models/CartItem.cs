using System.ComponentModel.DataAnnotations;

namespace web_final_projesi.Models
{
    public class CartItem
    {
        public int Id { get; set; }
        
        [Required]
        public string? SessionId { get; set; }
        
        public int ProductId { get; set; }
        public Product? Product { get; set; }
        
        [Required]
        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }
        
        public DateTime CreatedAt { get; set; }
    }
} 