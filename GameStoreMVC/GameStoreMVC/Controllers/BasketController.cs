using GameStoreMVC.DAL;
using GameStoreMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace GameStoreMVC.Controllers
{
    public class BasketController : Controller
    {
        private readonly AppDbContext _context;

        public BasketController(AppDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var basket = GetBasket();
            return View(basket);
        }
        public IActionResult AddToBasket(int gameId)
        {
            var basketItem = _context.Games.Find(gameId);
            if (basketItem == null)
            {
                return NotFound();
            }

            CookieOptions cookieOptions = new CookieOptions()
            {
                Expires = DateTime.Now.AddDays(7),
                HttpOnly = true
            };

            var basket = GetBasket();

            if (basket is null)
            {
                basket = new BasketVM();
            }
            
            BasketItemVM? exitingBasketItem = basket.basketItems.FirstOrDefault(g => g.GameId == gameId);

            if (exitingBasketItem == null)
            {
                BasketItemVM basketItemVm = new BasketItemVM()
                {
                    Price = basketItem.Price,
                    Title = basketItem.Title,
                    GameId = basketItem.Id,
                    ImageUrl = basketItem.ImageUrl,
                    Quantity = 1
                };

                basket.basketItems.Add(basketItemVm);
            }
            else
            {
                exitingBasketItem.Quantity = exitingBasketItem.Quantity + 1;
            }

            var basketJson = JsonConvert.SerializeObject(basket);
            Response.Cookies.Append("Basket", basketJson, cookieOptions);
            return RedirectToAction("Index", "Home");

        }

        public BasketVM GetBasket()
        {
            var basketJson = Request.Cookies["Basket"];
            if (basketJson is not null)
            {
                BasketVM? basketVM = JsonConvert.DeserializeObject<BasketVM>(basketJson);
                return basketVM;
            }
            return null;
        }
    }
}
