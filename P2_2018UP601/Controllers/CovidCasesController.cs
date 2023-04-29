using System.Linq;
using Microsoft.AspNetCore.Mvc;
using P2_2018UP601.Models;

namespace P2_2018UP601.Controllers
{
    public class CovidCasesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CovidCasesController(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var covidCases = _context.CovidCases.ToList();
            return View(covidCases);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CovidCase covidCase)
        {
            if (ModelState.IsValid)
            {
                _context.CovidCases.Add(covidCase);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(covidCase);
        }

        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var covidCase = _context.CovidCases.FirstOrDefault(m => m.Id == id);
            if (covidCase == null)
            {
                return NotFound();
            }

            return View(covidCase);
        }

        // Resto del controlador...
    }
}