namespace web_final_projesi.Models.ViewModels
{
    public class HomeViewModel
    {
        public List<Category>? Categories { get; set; }
        public List<Product>? FeaturedProducts { get; set; }

        public HomeViewModel()
        {
            Categories = new List<Category>();
            FeaturedProducts = new List<Product>();
        }
    }
} 