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
                "<select name='language'>" +
                "<option value='Hello'>English</option>" +
                "<option value='Bonjour'>French</option>" +
                "<option value='Hola'>Spanish</option>" +
                "<option value='Aloha'>Hawaiian</option>" +
                "<option value='Mabuhay'>Tagalog</option>" +
                "</select>" +
                "<input type='submit' value='Greet Me!' />" +
                "</form>";
            return Content(html, "text/html");
        }

        // Get: /helloworld/welcome
        // POST: /hello/welcome
        [HttpPost("welcome")]
        [HttpGet("welcome/{name?}/{language?}")]
        public IActionResult Welcome(string name = "World", string language = "English")
        {
            return Content($"<h1>{language}, {name}!</h1>", "text/html");
        }
    }
}
