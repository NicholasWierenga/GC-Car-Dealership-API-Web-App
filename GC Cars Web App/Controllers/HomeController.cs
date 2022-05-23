using GC_Cars_Web_App.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Diagnostics;

namespace GC_Cars_Web_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        public GCCarsDal dal = new GCCarsDal();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllCars()
        {
            List<Car> cars = dal.GetCars();

            Console.WriteLine(cars.Count);

            return View("SearchResults", cars);
        }

        public IActionResult SearchForCars(string Make, string Model, int Year, string Color)
        {
            List<Car> cars = dal.SearchForCars(Make ?? "null", Model ?? "null", Year, Color ?? "null");

            Console.WriteLine(cars.Count);

            return View("SearchResults", cars);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}