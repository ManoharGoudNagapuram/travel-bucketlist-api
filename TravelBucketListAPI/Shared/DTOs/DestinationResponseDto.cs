using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DTOs
{
    public class DestinationResponseDto
    {
        public string Name { get; set; }
        public string Country { get; set; }
        public bool Visited { get; set; } = false;
        public List<NotesResponseDto> Notes { get; set; } = new();
        public string Tags { get; set; }
    }
}
