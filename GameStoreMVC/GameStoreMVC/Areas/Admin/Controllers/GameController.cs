using GameStoreMVC.Areas.ViewModels.Game;
using GameStoreMVC.DAL;
using GameStoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

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
        public IActionResult Create(GameCreateVM gameVM)
        {
            Game game = new Game()
            {
                Title = gameVM.Title,
                Description = gameVM.Description,
                Price = gameVM.Price,
                GameId = gameVM.GameId,
                Image = gameVM.Image,
                CreatedDate = DateTime.Now
            };
            _context.Games.Add(game);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Update(int id)
        {
            Game? game = _context.Games.Find(id);
            return View(game);
        }
        [HttpPost]
        public IActionResult Update(Game game)
        {
            if(!ModelState.IsValid)
            {
                return View(game);
            }
            _context.Games.Update(game);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public IActionResult Delete(int id)
        {
            Game? deletedGame = _context.Games.Find(id);
            _context.Games.Remove(deletedGame);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Detail(int id)
        {
          Game? games = await  _context.Games.FirstOrDefaultAsync(x => x.Id == id);
          return View(games);
        }

    }
}
