using GameStoreMVC.DAL;
using GameStoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStoreMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GameController : Controller
    {
        private readonly AppDbContext _context;

        public GameController(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
           IEnumerable<Game> games = await _context.Games.ToListAsync();
            return View(games);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Game game)
        {
            _context.Games.Add(game);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
