﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_.NET_Hair_salon.Data;
using Proiect_.NET_Hair_salon.Models;

namespace Proiect_.NET_Hair_salon.Pages.Membri
{
    public class DetailsModel : PageModel
    {
        private readonly Proiect_.NET_Hair_salon.Data.Proiect_NET_Hair_salonContext _context;

        public DetailsModel(Proiect_.NET_Hair_salon.Data.Proiect_NET_Hair_salonContext context)
        {
            _context = context;
        }

      public Membru Membru { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Membru == null)
            {
                return NotFound();
            }

            var membru = await _context.Membru.FirstOrDefaultAsync(m => m.ID == id);
            if (membru == null)
            {
                return NotFound();
            }
            else 
            {
                Membru = membru;
            }
            return Page();
        }
    }
}
