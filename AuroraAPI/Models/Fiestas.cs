using System.ComponentModel.DataAnnotations;

namespace AuroraAPI.Models
{
    public class Fiestas
    {
        [Key]
        public int idFiesta { get; set; }
        public string nombreFiesta { get; set; }
        public string urlFlyer { get; set; }
    }
}