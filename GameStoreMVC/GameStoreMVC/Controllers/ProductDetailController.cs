using GameStoreMVC.DAL;
using GameStoreMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace GameStoreMVC.Controllers
{
    public class ProductDetailController : Controller
    {
        private readonly AppDbContext _context;

        public ProductDetailController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index(int id)
        {
            Game? game = _context.Games.FirstOrDefault(x => x.Id == id);
            if (game == null)
            {
                return NotFound();
            }
            GameComment gameComment = _context.GameComments.FirstOrDefault(x =>x.GameId == id);
        }
    }
}
