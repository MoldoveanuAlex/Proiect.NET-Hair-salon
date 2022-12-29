using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_.NET_Hair_salon.Data;
using Proiect_.NET_Hair_salon.Models;

namespace Proiect_.NET_Hair_salon.Pages.Programari
{
    public class CreateModel : PageModel
    {
        private readonly Proiect_.NET_Hair_salon.Data.Proiect_NET_Hair_salonContext _context;

        public CreateModel(Proiect_.NET_Hair_salon.Data.Proiect_NET_Hair_salonContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var serviciuList = _context.Serviciu
                .Include(b => b.Hairstylist)
                .Select(x => new
                {
                    x.ID,
                    ServiciuFullName = x.Nume + " by " + x.Hairstylist.Nume + " " + x.Hairstylist.Prenume
                });

            ViewData["ServiciuID"] = new SelectList(serviciuList, "ID", "ServiciuFullName");
            ViewData["MembruID"] = new SelectList(_context.Membru, "ID", "NumeComplet");
            return Page();
        }

        [BindProperty]
        public Programare Programare { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Programare.Add(Programare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
