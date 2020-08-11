using ASP_ValidationModel.Models;
using ASP_ValidationModel.ViewModels;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ASP_ValidationModel.Controllers
{
    public class HomeController : Controller
    {
        ValidationContext db;
        IWebHostEnvironment _appEnvironment;
        public HomeController(ValidationContext context, IWebHostEnvironment appEnvironment)
        {
            db = context;
            _appEnvironment = appEnvironment;
        }

        public async Task<IActionResult> Index()
        {
            ViewBag.People = await db.People.ToListAsync();

            return View();
        }

        public IActionResult Create() //(PersonViewModel model = null, string emptyString = "")
        {
            return View(); //(model);
        }
        [HttpPost]
        public async Task <IActionResult> Create(PersonViewModel model, IFormFile uploadedFile)
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

                if (uploadedFile != null)
                {
                    string path = "/avatars/" + uploadedFile.FileName;
                    using (FileStream fileStream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    {
                        await uploadedFile.CopyToAsync(fileStream);
                    }

                    person.AvatarName = uploadedFile.FileName;
                    person.AvatarPath = path;
                }

                await db.People.AddAsync(person);
                await db.SaveChangesAsync();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }
    }
}
