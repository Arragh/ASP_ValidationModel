using ASP_ValidationModel.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASP_ValidationModel.Controllers
{
    public class HomeController : Controller
    {
        ValidationContext db;
        public HomeController(ValidationContext context)
        {
            db = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Person person)
        {
            if (ModelState.IsValid)
                return Content($"{person.Name} - {person.Email}");
            else
                return View(person);
        }
    }
}
