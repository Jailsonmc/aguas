using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Consumo
    {
        [Key]
        public int Id { get; set; }
        public Cliente Cliente { get; set; }
        public double VolumeConsumido { get; set; }
        public int mes { get; set; }

    }
}