using System.ComponentModel.DataAnnotations;

namespace AuroraAPI.Models
{
    public class galeria
    {
        [Key]
        public int Id { get; set; }
        public string URLimg { get; set; }
        public string nombreArchivo { get; set; }
        public string MIME { get; set; }
        public DateTime fechaCarga { get; set; }
    }
}