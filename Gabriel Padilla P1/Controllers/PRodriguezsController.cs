using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Gabriel_Padilla_P1.Data;
using Gabriel_Padilla_P1.Models;

namespace Gabriel_Padilla_P1.Controllers
{
    public class PRodriguezsController : Controller
    {
        private readonly Gabriel_Padilla_P1Context _context;

        public PRodriguezsController(Gabriel_Padilla_P1Context context)
        {
            _context = context;
        }

        // GET: PRodriguezs
        public async Task<IActionResult> Index()
        {
            var gabriel_Padilla_P1Context = _context.PRodriguez.Include(p => p.Carrera);
            return View(await gabriel_Padilla_P1Context.ToListAsync());
        }

        // GET: PRodriguezs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pRodriguez = await _context.PRodriguez
                .Include(p => p.Carrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pRodriguez == null)
            {
                return NotFound();
            }

            return View(pRodriguez);
        }

        // GET: PRodriguezs/Create
        public IActionResult Create()
        {
            ViewData["CarreraId"] = new SelectList(_context.Set<Carrera>(), "Id", "Id");
            return View();
        }

        // POST: PRodriguezs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CampoString,CampoInt,CampoDecimal,CampoBool,CampoFecha,CarreraId")] PRodriguez pRodriguez)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pRodriguez);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarreraId"] = new SelectList(_context.Set<Carrera>(), "Id", "Id", pRodriguez.CarreraId);
            return View(pRodriguez);
        }

        // GET: PRodriguezs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pRodriguez = await _context.PRodriguez.FindAsync(id);
            if (pRodriguez == null)
            {
                return NotFound();
            }
            ViewData["CarreraId"] = new SelectList(_context.Set<Carrera>(), "Id", "Id", pRodriguez.CarreraId);
            return View(pRodriguez);
        }

        // POST: PRodriguezs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CampoString,CampoInt,CampoDecimal,CampoBool,CampoFecha,CarreraId")] PRodriguez pRodriguez)
        {
            if (id != pRodriguez.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pRodriguez);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PRodriguezExists(pRodriguez.Id))
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
            ViewData["CarreraId"] = new SelectList(_context.Set<Carrera>(), "Id", "Id", pRodriguez.CarreraId);
            return View(pRodriguez);
        }

        // GET: PRodriguezs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pRodriguez = await _context.PRodriguez
                .Include(p => p.Carrera)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pRodriguez == null)
            {
                return NotFound();
            }

            return View(pRodriguez);
        }

        // POST: PRodriguezs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pRodriguez = await _context.PRodriguez.FindAsync(id);
            if (pRodriguez != null)
            {
                _context.PRodriguez.Remove(pRodriguez);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PRodriguezExists(int id)
        {
            return _context.PRodriguez.Any(e => e.Id == id);
        }
    }
}
