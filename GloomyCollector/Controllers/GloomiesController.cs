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

        //[Authorize]
        [HttpPost]
        public IActionResult AddWishList(AddWishListViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                string userId = viewModel.UserId;
                int gloomyId = viewModel.GloomyId;

                WishList wishList = new WishList
                {
                    UserId = userId,
                    GloomyId = gloomyId
                };
                context.WishLists.Add(wishList);
                context.SaveChanges();

                //return Redirect("/Gloomies/MyWishList/"):
                //return Redirect("/Gloomies/Detail/" + gloomyId);
                return Redirect("/Gloomies/MyWishList/" + userId);
            }

            return View(viewModel);
        }

        /*[Authorize]
        [Route("/gloomies/mywishlist/{userId}")]
        public IActionResult MyWishList(string userId)
        {
            List<WishList> wishLists = context.WishLists.Where(e => e.UserId == userId).Include(e => e.GloomyId).ToList();
            MyWishListViewModel viewModel = new MyWishListViewModel(wishLists);
            return View(viewModel);
        }*/
        //[HttpPost]
        /*
        [Route("/gloomies/MyWishList/{userId?}")]
        public IActionResult MyWishList(string id)
        {
            //what we need:
            //use the gloomyIds that are received where g => g.UserId.ToList... for every gloomy id in this list, return the gloomy and add that gloomy to a list., we should return a list of gloomies

            List<int> gloomyIds = context.WishLists.Where(g => g.UserId == id).Select(g => g.GloomyId).ToList();
            List<Gloomy> wishGloomies = new List<Gloomy>();

            if(gloomyIds.Count != 0){
               
                foreach (int gloomyId in gloomyIds)
                {
                    IQueryable<Gloomy> q= context.Gloomies.Where(g => g.Id.Equals(gloomyId));
                    List<Gloomy> listableQ = q.ToList();
                    if(listableQ.Count != 0){
                        foreach (Gloomy listable in listableQ)
                    {
                            wishGloomies.Add(listable);
                        }
                    }
                    else {
                        return View("NoGloomies");
                    }
                if(wishGloomies.Count != 0){
                        
                            return View(wishGloomies);

                    }
                    else
                {
                        return View("NoGloomies");
                    }
                }
            }
            else
            {
            
                return View("NoGloomies");
            }
            return View();
        }*/

        [Route("/gloomies/MyWishList/{userId?}")]
        public IActionResult MyWishList(string userId){
            List<WishList> gloomyIdsWishLists = context.WishLists.Where(u => u.UserId == userId).ToList();
            List<int> gloomyIds = gloomyIdsWishLists.Select(p => p.GloomyId).ToList();
            List<Gloomy> wishGloomies = new List<Gloomy>();

            foreach (int gloomy in gloomyIds)
            {
                IQueryable<Gloomy> gQuery = context.Gloomies.Where(i => i.Id == gloomy);
                List<Gloomy> gQ = gQuery.ToList();
                foreach(Gloomy g in gQ){
                    wishGloomies.Add(g);
                }
        }
            ViewBag.wishListGloomies = wishGloomies;
            return View();
        }
}
}
