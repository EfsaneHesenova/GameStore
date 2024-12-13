using GameStoreMVC.Areas.Admin.ViewModels.GameVMs;
using GameStoreMVC.DAL;
using GameStoreMVC.Models;
using GameStoreMVC.Utilities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GameStoreMVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class GameController : Controller
    {
        private readonly AppDbContext _context;
        IWebHostEnvironment _webHostEnvironment;

        public GameController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
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
            if (!ModelState.IsValid)
            {
                return View(gameVM);
            }

            Game game = new Game()
            {
                Title = gameVM.Title,
                Description = gameVM.Description,
                Price = gameVM.Price,
                GameId = gameVM.GameId,
                CreatedDate = DateTime.Now
            };
            if (!gameVM.Image.CheckType())
            {
                ModelState.AddModelError("Image", "Please Only Image");
                return View(gameVM);
            }
            if (!gameVM.Image.CheckSize(5))
            {
                ModelState.AddModelError("Image", "Only 5mb");
                return View(gameVM);
            }
            string imageUrl = gameVM.Image.Upload(_webHostEnvironment.WebRootPath);
            game.ImageUrl = imageUrl;
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
            if (!ModelState.IsValid)
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
            Game? games = await _context.Games.FirstOrDefaultAsync(x => x.Id == id);
            return View(games);
        }

    }
}
