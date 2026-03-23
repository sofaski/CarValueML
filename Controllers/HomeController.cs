using Microsoft.AspNetCore.Mvc;
using CarValueML.Models;
using CarValueML.Services;
using CarValueML.Data;

namespace CarValueML.Controllers
{
    public class HomeController : Controller
    {
        private readonly CarMLService _mlService;
        private readonly ApplicationDbContext _context;

        public HomeController(CarMLService mlService, ApplicationDbContext context)
        {
            _mlService = mlService;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Predict(CarInputModel model)
        {
            if (!ModelState.IsValid)
                return View("Index", model);

            var result = _mlService.Predict(model);

            var historyItem = new PredictionHistory
            {
                Buying = model.Buying,
                Maint = model.Maint,
                Doors = model.Doors,
                Persons = model.Persons,
                LugBoot = model.LugBoot,
                Safety = model.Safety,
                EstimatedPriceCategory = model.EstimatedPriceCategory,
                PredictedClass = result.PredictedClass,
                CreatedAt = DateTime.Now
            };

            _context.Predictions.Add(historyItem);
            _context.SaveChanges();

            return View("Result", result);
        }

        public IActionResult History()
        {
            var history = _context.Predictions
                .OrderByDescending(x => x.CreatedAt)
                .ToList();

            return View(history);
        }

        [HttpPost]
        public IActionResult ClearHistory()
        {
            var allPredictions = _context.Predictions.ToList();
            _context.Predictions.RemoveRange(allPredictions);
            _context.SaveChanges();

            return RedirectToAction("History");
        }

        public IActionResult Privacy()
        {
            return View();
        }
    }
}