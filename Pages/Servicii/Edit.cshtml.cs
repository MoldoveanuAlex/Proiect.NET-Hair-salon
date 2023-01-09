using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_.NET_Hair_salon.Data;
using Proiect_.NET_Hair_salon.Models;

namespace Proiect_.NET_Hair_salon.Pages.Servicii
{
    [Authorize(Roles = "Admin")]
    public class EditModel : ServiciuCategoriiPageModel
    {
        private readonly Proiect_.NET_Hair_salon.Data.Proiect_NET_Hair_salonContext _context;

        public EditModel(Proiect_.NET_Hair_salon.Data.Proiect_NET_Hair_salonContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Serviciu Serviciu { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Serviciu == null)
            {
                return NotFound();
            }

            Serviciu =  await _context.Serviciu
                .Include(b=>b.Hairstylist)
                .Include(b=>b.CategoriiServiciu).ThenInclude(b=>b.Categorie)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.ID == id);
            
            if (Serviciu == null)
            {
                return NotFound();
            }

            PopulateAssignedCategoryData(_context, Serviciu);

            var hairstylistList = _context.Hairstylist.Select(x => new
            {
                x.ID,
                FullName = x.Nume + " " + x.Prenume
            });
            //ViewData["HairstylistID"] = new SelectList(_context.Set<Hairstylist>(), "ID", "FullName");
            ViewData["HairstylistID"] = new SelectList(hairstylistList, "ID", "FullName");
            return Page();
        }

        /*
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Serviciu).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ServiciuExists(Serviciu.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ServiciuExists(int id)
        {
          return _context.Serviciu.Any(e => e.ID == id);
        }
        */

        public async Task<IActionResult> OnPostAsync(int? id, string[] selectateCategorii)
        {
            if(id == null)
            {
                return NotFound();
            }

            var serviciuToUpdate = await _context.Serviciu
                .Include(i => i.Hairstylist)
                .Include(i => i.CategoriiServiciu)
                    .ThenInclude(i => i.Categorie)
                .FirstOrDefaultAsync(s => s.ID == id);
            if(serviciuToUpdate == null)
            {
                return NotFound();
            }

            if(await TryUpdateModelAsync<Serviciu>(
                serviciuToUpdate,
                "Serviciu",
                i=>i.Nume, i=>i.Pret, i=>i.Durata, i=>i.HairstylistID))
            {
                UpdateServiciuCategorii(_context, selectateCategorii, serviciuToUpdate);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            UpdateServiciuCategorii(_context, selectateCategorii, serviciuToUpdate);
            PopulateAssignedCategoryData(_context, serviciuToUpdate);
            return Page();
        }
    }
}
