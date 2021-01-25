using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GloomyCollector.Controllers
{
    public class HelloController : Controller
    {
        // GET: /<controller>/
        [HttpGet]
        [Route("/helloworld/")]
        public IActionResult Index()
        {
            string html = "<h1>Hello Gloomy Collectors!</h1>";
            return Content(html, "text/html");
        }

        //GET: /hello/welcome
        [HttpGet]
        [Route("/helloworld/welcome/{name?}")]
        public IActionResult Welcome(string name = "Gloomy Collector")
        {
            return Content("<h1>Welcome to my app, " + name + "!</h1>", "text/html");
        }
    }
}
