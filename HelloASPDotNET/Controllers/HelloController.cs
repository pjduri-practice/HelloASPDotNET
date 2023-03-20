using Microsoft.AspNetCore.Mvc;

namespace HelloASPDotNET.Controllers
{
    [Route("/helloworld")]
    public class HelloController : Controller
    {
        // GET:  /helloworld/
        [HttpGet]
        public IActionResult Index()
        {
            string html = "<form method='post' action='/helloworld/welcome'>" +
                "<input type='text' name='name' />" +
                "<input type='submit' value='Greet Me!' />" +
                "</form>";
            return Content(html, "text/html");
        }

        // Get: /helloworld/welcome
        // POST: /hello/welcome
        [HttpPost("welcome")]
        [HttpGet("welcome/{name?}")]
        public IActionResult Welcome(string name = "World")
        {
            return Content($"<h1>Welcome to my app, {name}!</h1>", "text/html");
        }
    }
}
