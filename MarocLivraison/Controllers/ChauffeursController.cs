using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MarocLivraison.Data;
using MarocLivraison.Models;
using Microsoft.AspNetCore.Authorization;

namespace MarocLivraison.Controllers
{
    [Authorize]
    public class ChauffeursController : Controller
    {
        private readonly DataContext _context;

        public ChauffeursController(DataContext context)
        {
            _context = context;
        }

        // GET: Chauffeurs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Chauffeurs.ToListAsync());
        }

        // GET: Chauffeurs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chauffeur = await _context.Chauffeurs
                .FirstOrDefaultAsync(m => m.ChauffeurID == id);
            if (chauffeur == null)
            {
                return NotFound();
            }

            return View(chauffeur);
        }

        // GET: Chauffeurs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Chauffeurs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ChauffeurID,CIN,NomComplet,NumPermis")] Chauffeur chauffeur)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chauffeur);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(chauffeur);
        }

        // GET: Chauffeurs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chauffeur = await _context.Chauffeurs.FindAsync(id);
            if (chauffeur == null)
            {
                return NotFound();
            }
            return View(chauffeur);
        }

        // POST: Chauffeurs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ChauffeurID,CIN,NomComplet,NumPermis")] Chauffeur chauffeur)
        {
            if (id != chauffeur.ChauffeurID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chauffeur);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChauffeurExists(chauffeur.ChauffeurID))
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
            return View(chauffeur);
        }

        // GET: Chauffeurs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var chauffeur = await _context.Chauffeurs
                .FirstOrDefaultAsync(m => m.ChauffeurID == id);
            if (chauffeur == null)
            {
                return NotFound();
            }

            return View(chauffeur);
        }

        // POST: Chauffeurs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var chauffeur = await _context.Chauffeurs.FindAsync(id);
            _context.Chauffeurs.Remove(chauffeur);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChauffeurExists(int id)
        {
            return _context.Chauffeurs.Any(e => e.ChauffeurID == id);
        }
    }
}
