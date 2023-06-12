using System;
using System.Linq;
using System.Threading.Tasks;
using LogisticManagerWorkspace.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace LogisticManagerWorkspace.Controllers
{
    [Bind("Id,Name,Description,Date,ClientName,Cost,Status")]
    public class ServicesController : Controller
    {
        private readonly LogisticManagerWorkspaceContext _context;

        public ServicesController(LogisticManagerWorkspaceContext context)
        {
            _context = context;
        }

        // GET: Services List: /Services/
        public async Task<IActionResult> Index(string searchString)
        {
            var services = from m in _context.Services
                           select m;

            if (!String.IsNullOrEmpty(searchString))
            {
                services = services.Where(s => s.Name.Contains(searchString));
            }

            return View(await services.ToListAsync());
        }

        [HttpPost]
        public string Index(string searchString, bool notUsed)
        {
            return "Поиск по фразе: " + searchString;
        }

        // POST: Services: /Services/Edit/{id}
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var categories = from m in _context.Categories
                             select m.Name;
            var clients = from m in _context.Clients
                          select m.Name;
            var statuses = from m in _context.Statuses
                          select m.Name;
            var service = await _context.Services.FindAsync(id);

            var clientServiceViewModel = new ClientServiceViewModel
            {
                Categories = new SelectList(await categories.ToListAsync()),
                Clients = new SelectList(await clients.ToListAsync()),
                Statuses = new SelectList(await statuses.ToListAsync()),
                Service = service
            };

            if (service == null)
            {
                return NotFound();
            }
            return View(clientServiceViewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Date,ClientName,Cost,Status")] Service service)
        {
            var serviceResult = new Service
            {
                Id = service.Id,
                Name = service.Name,
                Description = service.Description,
                Date = service.Date,
                ClientName = service.ClientName,
                Cost = service.Cost,
                Status = service.Status
            };

            if (ModelState.IsValid)
            {
                try
                {
                    
                    _context.Update(service);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ServiceExists(service.Id))
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
            return View(serviceResult);
        }

        // GET: /Services/Create
        public async Task<IActionResult> CreateAsync()
        {
            var categories = from m in _context.Categories
                             select m.Name;
            var clients = from m in _context.Clients
                          select m.Name;
            var statuses = from m in _context.Statuses
                           select m.Name;
            var service = new Service();

            var clientServiceViewModel = new ClientServiceViewModel
            {
                Categories = new SelectList(await categories.ToListAsync()),
                Clients = new SelectList(await clients.ToListAsync()),
                Statuses = new SelectList(await statuses.ToListAsync()),
                Service = service
            };

            return View(clientServiceViewModel);
        }

        // POST: /Services/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Name,Description,Date,ClientName,Cost,Status")] Service service)
        {
            var serviceResult = new Service
            {
                Name = service.Name,
                Description = service.Description,
                Date = service.Date,
                ClientName = service.ClientName,
                Cost = service.Cost,
                Status = service.Status
            };

            if (ModelState.IsValid)
            {
                _context.Add(service);
                await _context.SaveChangesAsync();
                
                return RedirectToAction(nameof(Index));
            }

            return View(serviceResult);
        }

        // GET: Services/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var service = await _context.Services.FindAsync(id);
            _context.Services.Remove(service);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        private bool ServiceExists(object Id)
        {
            throw new NotImplementedException();
        }
    }
}
