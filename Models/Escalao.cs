using System.Security.AccessControl;
using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Escalao
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Descricao { get; set; }
        [Required]
        public int RangeMin { get; set; }
        [Required]
        public int RangeMax { get; set; }
        [Required]
        public double ValorUnitario { get; set; }
    }
}