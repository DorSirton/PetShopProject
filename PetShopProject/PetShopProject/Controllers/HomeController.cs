using Microsoft.AspNetCore.Mvc;
using PetShop.Service.Interfaces;
using PetShopProject.Models;
using System.Diagnostics;

namespace PetShopProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHomeService MyHomeService;

        public HomeController(ILogger<HomeController> logger, IHomeService homeService)
        {
            _logger = logger;
            MyHomeService = homeService;
        }

        public IActionResult Index()
        {
            return View(MyHomeService.Get2TopAnimals());
        }
        public IActionResult FirstPage()
        {
            return View();
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}