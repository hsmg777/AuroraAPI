using System.ComponentModel.DataAnnotations;

namespace AuroraAPI.Models
{
    public class Reservas
    {
        [Key]
        public int idReserva { get; set; }
        public string nombreReserva { get; set; }
        public string apellidoReserva { get; set; }
        public string numeroPersonas { get; set; }
        public string hora { get; set; }
        public string telefono { get; set; }


    }
}
