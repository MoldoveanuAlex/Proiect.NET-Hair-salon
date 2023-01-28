using System.ComponentModel.DataAnnotations;

namespace Proiect_.NET_Hair_salon.Models
{
    public class Programare
    {
        public int ID { get; set; }
        public int? MembruID { get; set; }
        public Membru? Membru { get; set; }
        public int? ServiciuID { get; set; }
        public Serviciu? Serviciu { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Ora programare")]

        public DateTime OraProgramare { get; set; }
    }
}
