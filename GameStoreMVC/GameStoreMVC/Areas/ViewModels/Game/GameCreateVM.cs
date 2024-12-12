namespace GameStoreMVC.Areas.ViewModels.Game
{
    public class GameCreateVM
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int GameId { get; set; }
        public IFormFile Image { get; set; }

    }
}
