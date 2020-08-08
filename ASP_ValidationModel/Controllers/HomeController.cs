using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASP_ValidationModel.Models;
using ASP_ValidationModel.ViewModels;
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
            List<Section> sections = db.Sections.ToList();

            return View(sections);
        }

        [HttpGet]
        public IActionResult CreateSection()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateSection(AddSectionViewModel model)
        {
            if (string.IsNullOrEmpty(model.SectionTitle))
            {
                ModelState.AddModelError("SectionTitle", "Что-то пошло не так!");
            }

            if (ModelState.IsValid)
            {
                Section section = new Section()
                {
                    Id = Guid.NewGuid().ToString(),
                    SectionTitle = model.SectionTitle
                };

                db.Sections.Add(section);
                db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View(model);
        }




        public IActionResult CreateSubsection(AddSubsectionViewModel model = null, string sectionId = "")
        {
            //if (sectionId != "")
            //{
            //    model.SectionId = sectionId;
            //}
            return View(model);
        }
        [HttpPost]
        public IActionResult CreateSubsection(AddSubsectionViewModel model)
        {
            if (string.IsNullOrEmpty(model.SubsectionTitle))
            {
                ModelState.AddModelError("SubsectionTitle", "Слишком коротко");
            }

            if (ModelState.IsValid)
            {
                Subsection subsection = new Subsection()
                {
                    Id = Guid.NewGuid().ToString(),
                    SubsectionTitle = model.SubsectionTitle,
                    SectionId = model.SectionId
                };

                db.Subsections.Add(subsection);
                db.SaveChanges();

                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("CreateSubsection", "Home", new { model.SectionId });
        }
    }
}
