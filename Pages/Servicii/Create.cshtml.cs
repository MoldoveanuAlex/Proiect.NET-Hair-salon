using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Proiect_.NET_Hair_salon.Data;
using Proiect_.NET_Hair_salon.Models;

namespace Proiect_.NET_Hair_salon.Pages.Servicii
{
    public class CreateModel : ServiciuCategoriiPageModel
    {
        private readonly Proiect_.NET_Hair_salon.Data.Proiect_NET_Hair_salonContext _context;

        public CreateModel(Proiect_.NET_Hair_salon.Data.Proiect_NET_Hair_salonContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var hairstylistList = _context.Hairstylist.Select(x => new
            {
                x.ID,
                FullName = x.Nume + " " + x.Prenume
            });

            ViewData["HairstylistID"] = new SelectList(hairstylistList, "ID", "FullName");

            var serviciu = new Serviciu();
            serviciu.CategoriiServiciu = new List<CategorieServiciu>();
            PopulateAssignedCategoryData(_context, serviciu);

            return Page();
        }

        [BindProperty]
        public Serviciu Serviciu { get; set; }

        /*
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Serviciu.Add(Serviciu);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        */

        public async Task<IActionResult> OnPostAsync(string[] selectateCategorii)
        {
            var newServiciu = new Serviciu();
            if (selectateCategorii != null)
            {
                newServiciu.CategoriiServiciu = new List<CategorieServiciu>();
                foreach (var cat in selectateCategorii)
                {
                    var catToAdd = new CategorieServiciu
                    {
                        CategorieID = int.Parse(cat)
                    };
                    newServiciu.CategoriiServiciu.Add(catToAdd);
                }
            }

            Serviciu.CategoriiServiciu = newServiciu.CategoriiServiciu;
            _context.Serviciu.Add(Serviciu);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");

            PopulateAssignedCategoryData(_context, newServiciu);
            return Page();

        }
    }
}
