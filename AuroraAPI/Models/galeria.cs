using System.ComponentModel.DataAnnotations;

namespace AuroraAPI.Models
{
    public class galeria
    {
        [Key]
        public int Id { get; set; }
        public string URLimg { get; set; }
    }
}