using Microsoft.AspNetCore.Mvc;
using ShopProject.Models;
using ShopProject.ViewModels;

namespace ShopProject.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        //This is how we use DI that we have instatiated in the container in Program.cs (Constuctor Injection)
        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        //First action method
        //IActionResult is an interface type that all results will implement
        //public IActionResult List()
        //{
        //    //ViewBag.CurrentCategory = "Cheese cakes";
        //    //return View(_pieRepository.AllPies);

        //    PieListViewModel pieListViewModel = new PieListViewModel(_pieRepository.AllPies,"All Pies");
        //    return View(pieListViewModel);
        //}

        public ViewResult List(string category)
        {
            IEnumerable<Pie> pies;
            string? currentCategory;

            if(string.IsNullOrEmpty(category))
            {
                pies = _pieRepository.AllPies.OrderBy(p => p.PieId);
                currentCategory = "All Pies";
            }
            else
            {
                pies = _pieRepository.AllPies.Where(c => c.Category.CategoryName == category).OrderBy(p => p.PieId);
                currentCategory = _categoryRepository.AllCategories.FirstOrDefault(c => c.CategoryName == category)?.CategoryName;
            }

            return View(new PieListViewModel(pies, currentCategory));
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
                return NotFound();
            return View(pie);
        }
    }
}
