using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class DestinationRequestDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Country { get; set; }
        public bool Visited { get; set; } = false;
        public string Tags { get; set; } 
    }
}
