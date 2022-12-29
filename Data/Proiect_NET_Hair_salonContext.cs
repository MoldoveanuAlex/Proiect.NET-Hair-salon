using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Proiect_.NET_Hair_salon.Models;

namespace Proiect_.NET_Hair_salon.Data
{
    public class Proiect_NET_Hair_salonContext : DbContext
    {
        public Proiect_NET_Hair_salonContext (DbContextOptions<Proiect_NET_Hair_salonContext> options)
            : base(options)
        {
        }

        public DbSet<Proiect_.NET_Hair_salon.Models.Serviciu> Serviciu { get; set; } = default!;

        public DbSet<Proiect_.NET_Hair_salon.Models.Hairstylist> Hairstylist { get; set; }

        public DbSet<Proiect_.NET_Hair_salon.Models.CategorieServiciu> CategorieServiciu { get; set; }

        public DbSet<Proiect_.NET_Hair_salon.Models.Categorie> Categorie { get; set; }

        public DbSet<Proiect_.NET_Hair_salon.Models.Membru> Membru { get; set; }

        public DbSet<Proiect_.NET_Hair_salon.Models.Programare> Programare { get; set; }
    }
}
