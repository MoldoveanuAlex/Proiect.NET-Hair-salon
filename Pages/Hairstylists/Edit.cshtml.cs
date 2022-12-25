﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Proiect_.NET_Hair_salon.Data;
using Proiect_.NET_Hair_salon.Models;

namespace Proiect_.NET_Hair_salon.Pages.Hairstylists
{
    public class EditModel : PageModel
    {
        private readonly Proiect_.NET_Hair_salon.Data.Proiect_NET_Hair_salonContext _context;

        public EditModel(Proiect_.NET_Hair_salon.Data.Proiect_NET_Hair_salonContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Hairstylist Hairstylist { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Hairstylist == null)
            {
                return NotFound();
            }

            var hairstylist =  await _context.Hairstylist.FirstOrDefaultAsync(m => m.ID == id);
            if (hairstylist == null)
            {
                return NotFound();
            }
            Hairstylist = hairstylist;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Hairstylist).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HairstylistExists(Hairstylist.ID))
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

        private bool HairstylistExists(int id)
        {
          return _context.Hairstylist.Any(e => e.ID == id);
        }
    }
}
