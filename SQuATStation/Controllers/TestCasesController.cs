using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SQuATStation;
using SQuATStation.Data;

namespace SQuATStation.Controllers
{
    public class TestCasesController : Controller
    {
        private readonly SQuATStationContext _context;

        public TestCasesController(SQuATStationContext context)
        {
            _context = context;
        }

        // GET: TestCases
        public async Task<IActionResult> Index()
        {
              return _context.TestCase != null ? 
                          View(await _context.TestCase.ToListAsync()) :
                          Problem("Entity set 'SQuATStationContext.TestCase'  is null.");
        }

        // GET: TestCases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TestCase == null)
            {
                return NotFound();
            }

            var testCase = await _context.TestCase
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testCase == null)
            {
                return NotFound();
            }

            return View(testCase);
        }

        // GET: TestCases/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TestCases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,TestSuiteId,TestProjectId,CreatedDate")] TestCase testCase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(testCase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(testCase);
        }

        // GET: TestCases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TestCase == null)
            {
                return NotFound();
            }

            var testCase = await _context.TestCase.FindAsync(id);
            if (testCase == null)
            {
                return NotFound();
            }
            return View(testCase);
        }

        // POST: TestCases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,TestSuiteId,TestProjectId,CreatedDate")] TestCase testCase)
        {
            if (id != testCase.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(testCase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TestCaseExists(testCase.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(testCase);
        }

        // GET: TestCases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TestCase == null)
            {
                return NotFound();
            }

            var testCase = await _context.TestCase
                .FirstOrDefaultAsync(m => m.Id == id);
            if (testCase == null)
            {
                return NotFound();
            }

            return View(testCase);
        }

        // POST: TestCases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TestCase == null)
            {
                return Problem("Entity set 'SQuATStationContext.TestCase'  is null.");
            }
            var testCase = await _context.TestCase.FindAsync(id);
            if (testCase != null)
            {
                _context.TestCase.Remove(testCase);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TestCaseExists(int id)
        {
          return (_context.TestCase?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
