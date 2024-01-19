using System.ComponentModel.DataAnnotations;

namespace AuroraAPI.Models
{
    public class Fiestas
    {
        [Key]
        
        public int idFiesta {  get; set; }
        public string? NombreFiesta { get; set;}
        public string? Imagen {  get; set;}

    }
}
