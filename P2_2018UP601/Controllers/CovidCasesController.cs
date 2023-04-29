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

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var covidCase = _context.CovidCases.Find(id);
            if (covidCase == null)
            {
                return NotFound();
            }

            return View(covidCase);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, CovidCase covidCase)
        {
            if (id != covidCase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                _context.Update(covidCase);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            return View(covidCase);
        }

        public IActionResult Delete(int? id)
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

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var covidCase = _context.CovidCases.Find(id);
            _context.CovidCases.Remove(covidCase);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
    }
}