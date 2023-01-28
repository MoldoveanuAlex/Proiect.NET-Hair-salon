using System.ComponentModel.DataAnnotations;

namespace Proiect_.NET_Hair_salon.Models
{
    public class Serviciu
    {
        public int ID { get; set; }

        [Display(Name = "Nume serviciu")]
        [Required]
        public string Nume { get; set; }

        public int Pret { get; set; }

        public int Durata { get; set; }

        public int? HairstylistID { get; set; }
        public Hairstylist? Hairstylist { get; set; }

        public ICollection<CategorieServiciu>? CategoriiServiciu { get; set; }
    }
}
