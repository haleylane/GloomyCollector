using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using GloomyCollector.Data;
//using GloomyCollector.ViewModels;
using Microsoft.AspNetCore.Mvc;
using GloomyCollector.Models;
using GloomyCollector.ViewModels.GloomyCollector.ViewModels;
using GloomyCollector.ViewModels;
using Microsoft.EntityFrameworkCore;
//using GloomyCollector.ViewModels.GloomyCollector.ViewModels.GloomyDetailViewModel;

namespace GloomyCollector.Controllers
{
    public class GloomiesController : Controller
    {
        private GloomyDbContext context;

        public GloomiesController(GloomyDbContext dbContext)
        {
            context = dbContext;
        }

        // Get: /<controller>/
        public IActionResult Index()
        {
            List<Gloomy> gloomies = context.Gloomies.ToList();

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

                context.Gloomies.Add(newGloomy);
                context.SaveChanges();

                return Redirect("/Gloomies");
            }
            return View(addGloomyViewModel);
        }

        public IActionResult Delete()
        {
            ViewBag.gloomies = context.Gloomies.ToList();

            return View();
        }

        [HttpPost]
        public IActionResult Delete(int[] gloomiesId)
        {
            foreach(int gloomyId in gloomiesId)
            {
                Gloomy theGloomy = context.Gloomies.Find(gloomyId);
                context.Gloomies.Remove(theGloomy);
            }
            context.SaveChanges();

            return Redirect("/Gloomies");
        }

        [HttpGet]
        [Route("/gloomies/detail/{gloomyId}")]
        //public IActionResult Detail(int gloomyID = 16) for default value
        public IActionResult Detail(int gloomyId )
        {
            if (gloomyId == 0)
            {
                return Content("Gloomy id is null");
            } else {
                Gloomy theGloomy = context.Gloomies.Find(gloomyId);
                if (theGloomy != null)
                {
                    GloomyDetailViewModel viewModel = new GloomyDetailViewModel(theGloomy);
                    
                    return View(viewModel);
                }
                else
                {
                    return Redirect("/Gloomies");
                } }
            /*Gloomy gloom = context.Gloomies.Find(gloomyId);

            return View(gloom);*/
        }
    }
}
