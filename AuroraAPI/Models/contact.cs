using System.ComponentModel.DataAnnotations;

namespace AuroraAPI.Models
{
    public class contact
    {
        [Key]
        public int idContact {  get; set; }
        public string numero {  get; set; }
        public string correo { get; set; }

    }
}
