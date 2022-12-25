﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_.NET_Hair_salon.Data;
using Proiect_.NET_Hair_salon.Models;

namespace Proiect_.NET_Hair_salon.Pages.Hairstylists
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_.NET_Hair_salon.Data.Proiect_NET_Hair_salonContext _context;

        public DetailsModel(Proiect_.NET_Hair_salon.Data.Proiect_NET_Hair_salonContext context)
        {
            _context = context;
        }

      public Hairstylist Hairstylist { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Hairstylist == null)
            {
                return NotFound();
            }

            var hairstylist = await _context.Hairstylist.FirstOrDefaultAsync(m => m.ID == id);
            if (hairstylist == null)
            {
                return NotFound();
            }
            else 
            {
                Hairstylist = hairstylist;
            }
            return Page();
        }
    }
}
