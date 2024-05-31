using System.ComponentModel.DataAnnotations;
using System.Security.Policy;

namespace AuroraAPI.Models
{
    public class Fiestas
    {
        [Key]
        public int idFiesta { get; set; }
        public string dia { get; set; }
        public string fecha { get; set; }
        public string nombreFiesta { get; set; }
        public string descripcion { get; set; }
    }
}