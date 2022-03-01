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
    public class TourneesController : Controller
    {
        private readonly DataContext _context;

        public TourneesController(DataContext context)
        {
            _context = context;
        }

        // GET: Tournees
        public async Task<IActionResult> Index()
        {
            var dataContext = _context.Tournees.Include(t => t.Chauffeur).Include(t => t.Client).Include(t => t.Vehicule);
            return View(await dataContext.ToListAsync());
        }

        // GET: Tournees/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournees = await _context.Tournees
                .Include(t => t.Chauffeur)
                .Include(t => t.Client)
                .Include(t => t.Vehicule)
                .FirstOrDefaultAsync(m => m.TourneesID == id);
            if (tournees == null)
            {
                return NotFound();
            }

            return View(tournees);
        }

        // GET: Tournees/Create
        public IActionResult Create()
        {
            ViewData["ChauffeurID"] = new SelectList(_context.Chauffeurs, "ChauffeurID", "CIN");
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "NomResponsable");
            ViewData["VehiculeID"] = new SelectList(_context.Vehicules, "VehiculeID", "Marque");
            return View();
        }

        // POST: Tournees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TourneesID,ChauffeurID,VehiculeID,ClientID,DateLivraison,Kilometrage,NiveauCarburant,AdresseLivraison,DureeLivraison")] Tournees tournees)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tournees);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ChauffeurID"] = new SelectList(_context.Chauffeurs, "ChauffeurID", "CIN", tournees.ChauffeurID);
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "NomResponsable", tournees.ClientID);
            ViewData["VehiculeID"] = new SelectList(_context.Vehicules, "VehiculeID", "Marque", tournees.VehiculeID);
            return View(tournees);
        }

        // GET: Tournees/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournees = await _context.Tournees.FindAsync(id);
            if (tournees == null)
            {
                return NotFound();
            }
            ViewData["ChauffeurID"] = new SelectList(_context.Chauffeurs, "ChauffeurID", "CIN", tournees.ChauffeurID);
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "NomResponsable", tournees.ClientID);
            ViewData["VehiculeID"] = new SelectList(_context.Vehicules, "VehiculeID", "Marque", tournees.VehiculeID);
            return View(tournees);
        }

        // POST: Tournees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TourneesID,ChauffeurID,VehiculeID,ClientID,DateLivraison,Kilometrage,NiveauCarburant,AdresseLivraison,DureeLivraison")] Tournees tournees)
        {
            if (id != tournees.TourneesID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tournees);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TourneesExists(tournees.TourneesID))
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
            ViewData["ChauffeurID"] = new SelectList(_context.Chauffeurs, "ChauffeurID", "CIN", tournees.ChauffeurID);
            ViewData["ClientID"] = new SelectList(_context.Clients, "ClientID", "NomResponsable", tournees.ClientID);
            ViewData["VehiculeID"] = new SelectList(_context.Vehicules, "VehiculeID", "Marque", tournees.VehiculeID);
            return View(tournees);
        }

        // GET: Tournees/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tournees = await _context.Tournees
                .Include(t => t.Chauffeur)
                .Include(t => t.Client)
                .Include(t => t.Vehicule)
                .FirstOrDefaultAsync(m => m.TourneesID == id);
            if (tournees == null)
            {
                return NotFound();
            }

            return View(tournees);
        }

        // POST: Tournees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tournees = await _context.Tournees.FindAsync(id);
            _context.Tournees.Remove(tournees);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TourneesExists(int id)
        {
            return _context.Tournees.Any(e => e.TourneesID == id);
        }
    }
}
