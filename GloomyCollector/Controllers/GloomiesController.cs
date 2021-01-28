using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using GloomyCollector.Data;
using GloomyCollector.ViewModels;
using Microsoft.AspNetCore.Mvc;
using GloomyCollector.Models;
using GloomyCollector.ViewModels.GloomyCollector.ViewModels;

namespace GloomyCollector.Controllers
{
    public class GloomiesController : Controller
    {
        public IActionResult Index()
        {
            List<Gloomy> gloomies = new List<Gloomy>(GloomyData.GetAll());

            return View(gloomies);
        }

        public IActionResult Add()
        {
            AddGloomyViewModel addGloomyViewModel = new AddGloomyViewModel();

            return View(addGloomyViewModel);
        }
        
        [HttpPost]
        public IActionResult Add(AddGloomyViewModel addGloomyViewModel)

        {
            //checks if validation in gloomyviewmodel is correct
            if (ModelState.IsValid)
            {
                Gloomy newGloomy = new Gloomy
                {
                    SerialNumber = addGloomyViewModel.SerialNumber,
                    Name = addGloomyViewModel.Name,
                    Year = addGloomyViewModel.Year,
                    ImageData = addGloomyViewModel.ImageData
                };

                GloomyData.Add(newGloomy);

                return Redirect("/Gloomies");
            }
            return View(addGloomyViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.gloomies = GloomyData.GetAll();
            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] gloomiesId)
        {
            foreach(int gloomyId in gloomiesId)
            {
                GloomyData.Remove(gloomyId);
            }

            return Redirect("/Gloomies");
        }
    }
}
