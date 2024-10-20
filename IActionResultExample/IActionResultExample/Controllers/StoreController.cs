using Microsoft.AspNetCore.Mvc;

namespace IActionResultExample.Controllers
{
    public class StoreController : Controller
    {
        [Route("/store/books/{id}")]
        public IActionResult Books()
        {
            int id = Convert.ToInt32(Request.RouteValues["id"]);
            Console.WriteLine(id);
            return Content($"<h2>Book store id: {id} </h2>", "text/html");
        }
    }
}
