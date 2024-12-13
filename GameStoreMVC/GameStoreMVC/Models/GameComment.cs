using GameStoreMVC.Models.Base;

namespace GameStoreMVC.Models
{
    public class GameComment: BaseAuditableEntity
    {
        public string Comment { get; set; }
        public Game? Game { get; set; }
        public int GameId { get; set; }
    }
}
