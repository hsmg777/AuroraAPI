using System.ComponentModel.DataAnnotations;

namespace AuroraAPI.Models
{
    public class politicas
    {
        [Key]
        public int idPolitica {  get; set; }
        public string politica {  get; set; }
    }
}
