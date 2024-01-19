using System.ComponentModel.DataAnnotations;

namespace AuroraAPI.Models
{
    public class Reservas
    {
        [Key]
        public int idReserva { get; set; }
        public string Nombre { get; set; }
        public int NumeroPersonas { get; set; }
        public string Telefono { get; set; }
        public DateTime Fecha { get; set; }
        public string HoraLlega { get; set; }

    }
}
