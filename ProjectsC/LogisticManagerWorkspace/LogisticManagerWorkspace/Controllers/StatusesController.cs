using System;
using System.Linq;
using System.Threading.Tasks;
using LogisticManagerWorkspace.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LogisticManagerWorkspace.Controllers
{
    public class StatusesController : Controller
    {
        private readonly LogisticManagerWorkspaceContext _context;

        public StatusesController(LogisticManagerWorkspaceContext context)
        {
            _context = context;
        }

        // GET Statuses List: /<controller>/
        public async Task<IActionResult> Index(string searchString)
        {
            var statuses = from m in _context.Statuses
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                statuses = statuses.Where(s => s.Name.Contains(searchString));
            }

            return View(await statuses.ToListAsync());
        }

        // GET Statuses: /<controller>/Details/5
        public async Task<IActionResult> Details(int? id = null)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _context.Statuses
                .FirstOrDefaultAsync(m => m.Id == id);
            if (status == null)
            {
                return NotFound();
            }

            return View(status);
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "Поиск по фразе: " + searchString;
        }

        // GET Edit Status: /<controller>/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _context.Statuses.FindAsync(id);
            if (status == null)
            {
                return NotFound();
            }
            return View(status);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int Id, [Bind("Id,Name,Description")] Status status)
        {
            if (Id != status.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(status);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!StatusExists(status.Id))
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
            return View(status);
        }

        // GET: Statuses/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Statuses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(
            [Bind("Name,Description")] Status status)
        {
            if (ModelState.IsValid)
            {
                _context.Add(status);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(status);
        }

        // GET: Statuses/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var status = await _context.Statuses.FindAsync(id);
            _context.Statuses.Remove(status);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool StatusExists(object Name)
        {
            throw new NotImplementedException();
        }
    }
}
