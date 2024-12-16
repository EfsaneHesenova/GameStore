using GameStoreMVC.Areas.Admin.ViewModels.GameVMs;
using GameStoreMVC.DAL;
using GameStoreMVC.Models;
using GameStoreMVC.ViewModels;
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
            ICollection<GameComment>? gameComments = _context.Comments.Where(x => x.GameId == id).ToList();
            game.GameComments = gameComments;
            ProductDetailVM productDetailVM = new ProductDetailVM()
            {
                Id = game.Id,
                Title = game.Title,
                Description = game.Description,
                Price = game.Price,
                GameId = game.GameId,
                ImageUrl = game.ImageUrl,
                GameComments = game.GameComments,
            };
            return View(productDetailVM);          
        }

        [HttpPost]
        public IActionResult Index(ProductDetailVM productDetailVM)
        {
            if(!ModelState.IsValid)
            {
                return View(productDetailVM);
            }
            GameComment gameComment = new GameComment()
            {
                GameId = productDetailVM.Id,
                Comment = productDetailVM.Comment,
            };
            _context.Comments.Add(gameComment);
            _context.SaveChanges();
            ModelState.Clear();
            return RedirectToAction("Index", new {id=productDetailVM.Id});
        }
    }
}
