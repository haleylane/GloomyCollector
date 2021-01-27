using System;
using System.Collections.Generic;
using GloomyCollector.Data;
using GloomyCollector.Models;
using Microsoft.AspNetCore.Mvc;

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
            return View();
        }

        [HttpPost]
        [Route("Gloomies/Add")]
        public IActionResult NewGloomy(Gloomy newGloomy)
        {
            GloomyData.Add(newGloomy);
            return Redirect("/Gloomies");
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
