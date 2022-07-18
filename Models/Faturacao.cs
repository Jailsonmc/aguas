using System.ComponentModel.DataAnnotations;

namespace backend.Models
{
    public class Faturacao
    {
        [Key]
        public int Id { get; set; }
        public Consumo Consumo { get; set; }
        public double valor { get; set; }

    }
}