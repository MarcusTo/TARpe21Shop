using Microsoft.AspNetCore.Mvc;

namespace TARpe21ShopVaitmaa.Models.Car
{
    public class CarIndexViewModel : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
