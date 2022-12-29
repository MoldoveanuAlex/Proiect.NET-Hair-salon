using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Proiect_.NET_Hair_salon.Data;

namespace Proiect_.NET_Hair_salon.Models
{
    public class ServiciuCategoriiPageModel:PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Proiect_NET_Hair_salonContext context, Serviciu serviciu)
        {
            var toateCategorii = context.Categorie;
            var serviciuCategorii = new HashSet<int>(
                serviciu.CategoriiServiciu.Select(c => c.CategorieID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach(var cat in toateCategorii)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategorieID = cat.ID,
                    Nume = cat.NumeCategorie,
                    Atribuita = serviciuCategorii.Contains(cat.ID)
                });
            }
        }

        public void UpdateServiciuCategorii(Proiect_NET_Hair_salonContext context,
            string[] selectateCategorii, Serviciu serviciuToUpdate)
        {
            if(selectateCategorii == null)
            {
                serviciuToUpdate.CategoriiServiciu = new List<CategorieServiciu>();
                return;
            }

            var selectateCategoriiHS = new HashSet<string>(selectateCategorii);
            var serviciuCategorii = new HashSet<int>
                (serviciuToUpdate.CategoriiServiciu.Select(c=>c.Categorie.ID)); 

            foreach(var cat in context.Categorie)
            {
                if(selectateCategoriiHS.Contains(cat.ID.ToString()))
                {
                    if(!serviciuCategorii.Contains(cat.ID))
                    {
                        serviciuToUpdate.CategoriiServiciu.Add(
                            new CategorieServiciu
                            {
                                ServiciuID = serviciuToUpdate.ID,
                                CategorieID = cat.ID
                            });
                    }
                }
                else
                {
                    if(serviciuCategorii.Contains(cat.ID))
                    {
                        CategorieServiciu courseToRemove =
                            serviciuToUpdate
                                .CategoriiServiciu
                                .SingleOrDefault(i => i.CategorieID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }
    }
}
