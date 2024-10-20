using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("/bookstore")]
        public IActionResult Index()
        {
            if (!Request.Query.ContainsKey("BookId"))
            {
                return BadRequest("BookId is not found...");
            }
            else
            {
                if (int.Parse(Request.Query["BookId"]) > 1000 || int.Parse(Request.Query["BookId"]) < 1)
                {
                    return BadRequest("Book id Out of bounds...");
                }
            }
            if (!Request.Query.ContainsKey("isLoggedIn"))
            {
                return BadRequest("Authentacation Error...");
            }
            else
            {
                if (Request.Query["isLoggedIn"] == "false")
                {
                    return BadRequest("User not loggedIn...");
                }
            }
            int BookId = Convert.ToInt32(Request.Query["BookId"]);
            //return new RedirectToActionResult("Books", "Store", new {}); // url move and found
            //return new RedirectToActionResult("Books", "Store", new {}, true); // url move and found
            //return RedirectToActionPermanent("Books", "Store", new { id = BookId }); // 301 url permanently move
            return LocalRedirectPermanent($"/store/books/{BookId}"); // 301 url permanently move
            return RedirectPermanent("https://www.linkedin.com/in/abdul-aziz-956209253/"); // 301 url permanently move
        }
    }
}
