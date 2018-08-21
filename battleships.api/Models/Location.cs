using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace battleships.api.Models
{
    public class Location
    {
        public int Row { get; set; }
        public char Column { get; set; }
        public Direction Placement { get; set; }
    }
}
