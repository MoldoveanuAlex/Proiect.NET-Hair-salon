﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Proiect_.NET_Hair_salon.Data;
using Proiect_.NET_Hair_salon.Models;

namespace Proiect_.NET_Hair_salon.Pages.Servicii
{
    public class IndexModel : PageModel
    {
        private readonly Proiect_.NET_Hair_salon.Data.Proiect_NET_Hair_salonContext _context;

        public IndexModel(Proiect_.NET_Hair_salon.Data.Proiect_NET_Hair_salonContext context)
        {
            _context = context;
        }

        public IList<Serviciu> Serviciu { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Serviciu = await _context.Serviciu
                .Include(b=>b.Hairstylist)
                .ToListAsync();
        }
    }
}
