using System;
using System.Linq;
using System.Data;
using System.Collections.Generic;
using System.Threading.Tasks;
using GloomyCollector.Data;
using Microsoft.AspNetCore.Mvc;
using GloomyCollector.Models;
using GloomyCollector.ViewModels.GloomyCollector.ViewModels;
using GloomyCollector.ViewModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

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
        [AllowAnonymous]
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
        //limit to only admin
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

        //limit to only admin
        public IActionResult Delete()
        {
            ViewBag.gloomies = context.Gloomies.ToList();

            return View();
        }

        [HttpPost]
        //limit to only admin
        public IActionResult Delete(int[] gloomiesId)
        {
            foreach (int gloomyId in gloomiesId)
            {
                Gloomy theGloomy = context.Gloomies.Find(gloomyId);
                context.Gloomies.Remove(theGloomy);
            }
            context.SaveChanges();

            return Redirect("/Gloomies");
        }

        //limit to only admin
        [HttpGet]
        [Route("/gloomies/detail/{gloomyId}")]
        public IActionResult Detail(int gloomyId)
        {
            if (gloomyId == 0)
            {
                return Content("Gloomy id is null");
            }
            else
            {
                Gloomy theGloomy = context.Gloomies.Find(gloomyId);
                if (theGloomy != null)
                {
                    GloomyDetailViewModel viewModel = new GloomyDetailViewModel(theGloomy);

                    return View(viewModel);
                }
                else
                {
                    return Redirect("/Gloomies");
                }
            }


        }

        [Authorize]
        public IActionResult AddWishList(string id)
        {
            GloomyUser theGloomyUser = context.GloomyUsers.Find(id);
            List<Gloomy> possibleGloomies = context.Gloomies.ToList();

            AddWishListViewModel viewModel = new AddWishListViewModel(theGloomyUser, possibleGloomies);

            return View(viewModel);
        }

        [Authorize]
        [HttpPost]
        public IActionResult AddWishList(AddWishListViewModel viewModel)
        {
            if (ModelState.IsValid){
                string userId = viewModel.UserId;
                int gloomyId = viewModel.GloomyId;

                WishList wishList = new WishList
                {
                    UserId = userId,
                    GloomyId = gloomyId
                };
                context.WishLists.Add(wishList);
                context.SaveChanges();

                return Redirect("/Gloomies/Detail/" + gloomyId);
            }

            return View(viewModel);
        }
    }
}
