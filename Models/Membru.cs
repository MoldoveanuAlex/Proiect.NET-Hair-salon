using System.ComponentModel.DataAnnotations;

namespace Proiect_.NET_Hair_salon.Models
{
    public class Membru
    {
        public int ID{ get; set; }
        public string? Prenume { get; set; }
        public string? Nume{ get; set; }
        public string Email { get; set; }
        public string? Telefon { get; set; }

        [Display(Name = "NumeComplet")]
        public string? NumeComplet
        {
            get
            {
                return Nume + " " + Prenume;
            }
        }
        public ICollection<Programare>? Programari { get; set; }
    }
}
