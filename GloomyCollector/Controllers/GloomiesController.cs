using System;
using GloomyCollector.Data;
using GloomyCollector.Models;
using Microsoft.AspNetCore.Mvc;

namespace GloomyCollector.Controllers
{
    public class GloomiesController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.gloomies = GloomyData.GetAll();

            return View();
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
    }
}
