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

        public IActionResult Create() //(PersonViewModel model = null, string emptyString = "")
        {
            return View(); //(model);
        }
        [HttpPost]
        public IActionResult Create(PersonViewModel model)
        {
            // Делаем проверку возраста на стороне сервера, т.к. пока не нашел как это сделать на клиенте
            if (model.Age < 10)
            {
                ModelState.AddModelError("Age", "Извини, но ты еще молокосос и не можешь регистрироваться");
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
