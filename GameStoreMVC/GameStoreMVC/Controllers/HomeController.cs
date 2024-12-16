using GameStoreMVC.DAL;
using GameStoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace GameStoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
          List<Game> games =  _context.Games.OrderByDescending(x => x.Id).Take(4).ToList();
          return View(games);
        }
    }
}
