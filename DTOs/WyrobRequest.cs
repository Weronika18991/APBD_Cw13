using System.ComponentModel.DataAnnotations;

namespace Cw13.DTOs
{
    public class WyrobRequest
    {
        [Required]
        public int ilosc { get; set; }
        [Required]
        public string wyrob { get; set; }
        public string uwagi { get; set; }
    }
}