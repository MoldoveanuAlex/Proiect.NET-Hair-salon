namespace Proiect_.NET_Hair_salon.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        public string NumeCategorie { get; set; }

        public ICollection<CategorieServiciu>? CategoriiServiciu { get; set; }
    }
}
