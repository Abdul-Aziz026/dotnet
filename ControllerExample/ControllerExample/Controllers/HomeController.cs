using Microsoft.AspNetCore.Mvc;
using ControllerExample.Models;

namespace ControllerExample.Controllers
{
    public class HomeController : Controller
    {
        [Route("/home")]
        [Route("/")]
        public ContentResult Home()
        {
            return Content("Alhamdulillah! I am from Home", "text/plain");
        }

        [Route("/person")]
        public JsonResult Person()
        {
            Person person = new Person(){
                Id = new Guid(),
                firstName = "Abdul",
                lastName = "Aziz",
                Age = 26
            };
            //return new JsonResult(person);
            return Json(person);
        }

        [Route("/about")]
        public string About()
        {
            return "Alhamdulillah! I am from About";
        }
        [Route("/contact")]
        public string Contact()
        {
            return "Alhamdulillah! I am from Contact";
        }

        [Route("/file-download1")]
        public VirtualFileResult FileDownload1()
        {
            //return new VirtualFileResult("Rahe-Bilawat.pdf", "application/pdf");
            return File("Rahe-Bilawat.pdf", "application/pdf");
        }


        [Route("/file-download2")]
        public PhysicalFileResult FileDownload2()
        {
            //return new PhysicalFileResult("F:\\Orbitax\\dotnet\\dotnet\\ControllerExample\\ControllerExample\\wwwroot\\Rahe-Bilawat.pdf", "application/pdf");
            return PhysicalFile("F:\\Orbitax\\dotnet\\dotnet\\ControllerExample\\ControllerExample\\wwwroot\\Rahe-Bilawat.pdf", "application/pdf");
        }

        [Route("/file-download3")]
        public FileContentResult FileDownload3()
        {
            byte[] bytes = System.IO.File.ReadAllBytes("F:\\Orbitax\\dotnet\\dotnet\\ControllerExample\\ControllerExample\\wwwroot\\Rahe-Bilawat.pdf");
            //return new FileContentResult(bytes, "application/pdf");
            return File(bytes, "application/pdf");
        }
    }
}
