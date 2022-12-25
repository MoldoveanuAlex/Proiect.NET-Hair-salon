namespace Proiect_.NET_Hair_salon.Models
{
    public class Hairstylist
    {
        public int ID { get; set; }
        public string Prenume { get; set; }
        public string Nume { get; set; }
        
        public ICollection<Serviciu>? Servicii { get; set; }
    }
}
