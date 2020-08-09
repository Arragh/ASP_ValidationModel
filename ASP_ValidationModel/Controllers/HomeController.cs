using ASP_ValidationModel.Models;
using ASP_ValidationModel.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System;

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

        public IActionResult Create(PersonViewModel model = null, string emptyString = "")
        {
            return View(model);
        }
        [HttpPost]
        public IActionResult Create(PersonViewModel model)
        {
            if (string.IsNullOrEmpty(model.Name))
            {
                ModelState.AddModelError("Name", "Необходимо ввести имя");
            }
            else if (model.Name.Length < 5)
            {
                ModelState.AddModelError("Name", "Имя слишком короткое");
            }

            if (ModelState.IsValid)
            {
                Person person = new Person()
                {
                    Id = Guid.NewGuid(),
                    Name = model.Name,
                    Email = model.Email,
                    Password = model.Password,
                    Age = model.Age
                };

                db.People.Add(person);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
