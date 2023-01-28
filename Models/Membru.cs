using System.ComponentModel.DataAnnotations;

namespace Proiect_.NET_Hair_salon.Models
{
    public class Membru
    {
        public int ID{ get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$", 
            ErrorMessage = "Prenumele trebuie sa inceapa cu majuscula! ")]
        [StringLength(30, MinimumLength = 3)]
        public string? Prenume { get; set; }

        [RegularExpression(@"^[A-Z]+[a-zA-Z\s-]*$",
           ErrorMessage = "Numele trebuie sa inceapa cu majuscula! ")]
        [StringLength(30, MinimumLength = 3)]
        public string? Nume{ get; set; }
        public string Email { get; set; }
        [RegularExpression(@"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{3})$", 
            ErrorMessage = "Numarul de telfon trebuie sa fie de forma '0722-123-123' sau '0722.123.123' sau '0722 123 123'")]
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
