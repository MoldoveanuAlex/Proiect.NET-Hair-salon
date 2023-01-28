using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_.NET_Hair_salon.Data;
using Proiect_.NET_Hair_salon.Models;

namespace Proiect_.NET_Hair_salon.Pages.Servicii
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly Proiect_.NET_Hair_salon.Data.Proiect_NET_Hair_salonContext _context;

        public DeleteModel(Proiect_.NET_Hair_salon.Data.Proiect_NET_Hair_salonContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Serviciu Serviciu { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Serviciu == null)
            {
                return NotFound();
            }

            var serviciu = await _context.Serviciu.FirstOrDefaultAsync(m => m.ID == id);

            if (serviciu == null)
            {
                return NotFound();
            }
            else 
            {
                Serviciu = serviciu;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Serviciu == null)
            {
                return NotFound();
            }
            var serviciu = await _context.Serviciu.FindAsync(id);

            if (serviciu != null)
            {
                Serviciu = serviciu;
                _context.Serviciu.Remove(Serviciu);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
