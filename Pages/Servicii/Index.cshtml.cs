using System;
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
        public ServiciuData ServiciuD { get; set; }
        public int ServiciuID { get; set; }
        public int CategorieID { get; set; }
        /*
        public async Task OnGetAsync()
        {
            Serviciu = await _context.Serviciu
                .Include(b=>b.Hairstylist)
                .ToListAsync();
        }
        */

        public async Task OnGetAsync(int? id, int? categorieID)
        {
            ServiciuD = new ServiciuData();
            ServiciuD.Servicii = await _context.Serviciu
                .Include(b => b.Hairstylist)
                .Include(b => b.CategoriiServiciu)
                .ThenInclude(b => b.Categorie)
                .AsNoTracking()
                .OrderBy(b => b.Nume)
                .ToListAsync();

            if(id != null)
            {
                ServiciuID = id.Value;
                Serviciu serviciu = ServiciuD.Servicii
                    .Where(i => i.ID == id.Value).Single();
                ServiciuD.Categorii = serviciu.CategoriiServiciu.Select(s => s.Categorie);
            }
        }
    }
}
