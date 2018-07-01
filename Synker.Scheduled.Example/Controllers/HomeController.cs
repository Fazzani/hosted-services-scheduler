namespace Synker.Scheduled.Example.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Synker.Scheduled.Example.HostedServices;
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Quote = QuoteOfTheDay.Current.Quote;
            ViewBag.Author = QuoteOfTheDay.Current.Author;

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
