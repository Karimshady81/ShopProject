using Microsoft.AspNetCore.Mvc;

namespace ShopProject.Controllers
{
    public class ContactController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
