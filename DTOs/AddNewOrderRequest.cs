using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Cw13.Models;

namespace Cw13.DTOs
{
    public class AddNewOrderRequest
    {
        [Required]
        public DateTime dataPrzyjecia { get; set; }
        [Required]
        public string uwagi { get; set; }
        [Required]
        public ICollection<WyrobRequest> wyroby { get; set; }
    }
}