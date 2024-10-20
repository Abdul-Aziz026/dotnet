using Microsoft.AspNetCore.Mvc;

namespace bookCRUD.Controllers
{
    public class HomeController : Controller
    {

        private static int bookCount = 0;

        // Index page
        [HttpGet("/")]
        public IActionResult Index()
        {
            return Ok("Home Page");
        }

        // API to add a certain number of books
        [HttpPost("add-book")]
        public IActionResult AddBook([FromBody] int count)
        {
            if (count > 0)
            {
                bookCount += count;
                return Ok($"{count} books added successfully. Total books: {bookCount}");
            }
            return BadRequest("The number of books to add must be greater than zero.");
        }

        // API to remove a certain number of books
        [HttpDelete("remove-book")]
        public IActionResult RemoveBook([FromBody] int count)
        {
            if (count > 0 && bookCount >= count)
            {
                bookCount -= count;
                return Ok($"{count} books removed successfully. Total books: {bookCount}");
            }
            else if (count > bookCount)
            {
                return BadRequest("Cannot remove more books than available.");
            }
            return BadRequest("The number of books to remove must be greater than zero.");
        }

        // API to count the current number of books
        [HttpGet("countcurrentbook")]
        public IActionResult CountCurrentBook()
        {
            return Ok($"Current No of Books: {bookCount}");
        }
    }
}
