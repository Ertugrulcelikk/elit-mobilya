using System.ComponentModel.DataAnnotations;

namespace web_final_projesi.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        [Required]
        public string? CustomerName { get; set; }
        
        [Required]
        public string? CustomerEmail { get; set; }
        
        [Required]
        public string? CustomerPhone { get; set; }
        
        [Required]
        public string? ShippingAddress { get; set; }
        
        public decimal TotalAmount { get; set; }
        
        public string? OrderStatus { get; set; } 
        
        public DateTime OrderDate { get; set; }
        
        public List<OrderItem>? OrderItems { get; set; }
    }
} 