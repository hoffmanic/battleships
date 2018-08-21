using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace battleships.api.Models
{
    public class GameBoard
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public List<Battleship> Battleships { get; set; }
    }
}
