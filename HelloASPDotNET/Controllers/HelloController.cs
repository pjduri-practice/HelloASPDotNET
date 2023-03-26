using Microsoft.AspNetCore.Mvc;

namespace HelloASPDotNET.Controllers
{
    
    public class HelloController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [Route("/hello")]
        public IActionResult Welcome(string name)
        {
            ViewBag.vegsByPrice = new Dictionary<string, double>();
            ViewBag.vegsByPrice.Add("Rutabaga", 5.56);
            ViewBag.vegsByPrice.Add("Cucumber", 3.92);
            ViewBag.vegsByPrice.Add("Celery", 4.65);
            ViewBag.vegsByPrice.Add("Cauliflower", 7.89);
            ViewBag.vegsByPrice.Add("Broccoli", 7.88);
            ViewBag.vegsByPrice.Add("Green Beans", 2.33);
            ViewBag.person = name;
            return View();
        }
    }
}
