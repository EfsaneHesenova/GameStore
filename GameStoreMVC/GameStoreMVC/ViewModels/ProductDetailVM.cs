using GameStoreMVC.Models;

namespace GameStoreMVC.ViewModels
{
    public class ProductDetailVM
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public int? Price { get; set; }
        public int? GameId { get; set; }
        public string? ImageUrl { get; set; }
        public ICollection<GameComment>? GameComments { get; set; }
        public string Comment { get; set; }
    }
}
