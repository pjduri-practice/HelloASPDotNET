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
                "<input type='text' name='name'/>" +
                "<select name='helloTranslate'>" +
                "<option value='Hello' selected>English</option>" +
                "<option value='Bonjour'>French</option>" +
                "<option value='NiHao'>Mandarin</option>" +
                "<option value='Hola'>Spanish</option>" +
                "<option value='Hallo'>German</option>" +
                "</select>" +
                "<input type='submit' value='Greet Me!' />" +
                "</form>";
            return Content(html, "text/html");
        }

        // here's a working version of what I was trying to do in 
        // class today.  one reason I think this is ultimately not the best
        // way to go about this is the single purpose principle.  
        // this version of CreateMessage both creates the message
        // and passes it to the view.  by creating a static method 
        // to create the message we could create another controller that 
        // routes to "/helloworld/goodnight" with an appropriately 
        // translated greeting
        [HttpPost("welcome")]
        [HttpGet("welcome/{helloTranslate}/{name?}")]
        public IActionResult CreateMessage(string helloTranslate, string name)
        {
            // the null check seems to be the only one that affects 
            // anything, but I kind of consider it good 
            // practice to check for both if you're checking for one.
            // then again, it's not always necessarily strings that 
            // we'll be checking
            if (name == "" || name == null)
            {
                name = "World";
            }
            string html = $"<h1>{helloTranslate}, {name}!</h1>";
            return Content(html, "text/html");
        }

        // book solution doesn't include this, though that might be part
        // of the "training wheels off" aspect of unit 2
        // the Welcome method is refactored to use CreateMessage
        // method's return value by passing helloTranslate
        // and name as arguments. this will also work with
        // the book's version of CreateMessage that uses the
        // switch, the values for the option elements
        // in our html would need to be changed back 
        // to the language abbreviations.

        // Get: /helloworld/welcome
        // POST: /hello/welcome
        //[HttpPost("welcome")]
        //[HttpGet("welcome/{helloTranslate}/{name?}")]
        //public IActionResult Welcome(string helloTranslate, string name)
        //{
        //    return Content(CreateMessage(helloTranslate, name), "text/html");
        //}


        // here's a version of createMessage that works without using 
        // the switch.  again, checking if name is null seems to be 
        // what actually affects things here, but I've included 
        // a check for an empty string as well.
        // if I were to make an argument for doing it this way, 
        // it would be that this allows multiple views, with perhaps
        // different language selections, to also use this method
        // Which way is best?  Everybody's favorite two words - it depends.
        
        //public static string CreateMessage(string translatedGreeting, string aName)
        //{
        //    if (aName == "" || aName == null)
        //    {
        //        aName = "World";
        //    }
        //    return $"<h1>{translatedGreeting}, {aName}!</h1>";
        //}

    }
}
