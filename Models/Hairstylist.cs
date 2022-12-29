using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace Proiect_.NET_Hair_salon.Models
{
    public class Hairstylist
    {
        public int ID { get; set; }
        public string Prenume { get; set; }
        public string Nume { get; set; }
        [Display(Name = "NumeComplet")]
        public string? NumeComplet
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }

        public ICollection<Serviciu>? Servicii { get; set; }
    }
}
