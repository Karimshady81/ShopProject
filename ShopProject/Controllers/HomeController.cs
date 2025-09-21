using Microsoft.AspNetCore.Mvc;
using ShopProject.Models;
using ShopProject.ViewModels;

namespace ShopProject.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;
        public HomeController(IPieRepository pieRepository)
        {
            _pieRepository = pieRepository;
        }

        public IActionResult Index()
        {
            var pieOfTheWeek = _pieRepository.PiesOfTheWeek;
            var homeViewModel = new HomeViewModel(pieOfTheWeek);
            return View(homeViewModel);
        }
    }
}
