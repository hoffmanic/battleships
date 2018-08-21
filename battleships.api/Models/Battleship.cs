using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace battleships.api.Models
{
    public class Battleship
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public int Length { get; set; }
        public List<Coordinate> Hits { get; set; } = new List<Coordinate>();
        public Location Location { get; set; }
        public BattleshipStatus Status
        {
            get
            {
                if (Location == null) return BattleshipStatus.NotPlaced;
                if (Hits.Count == Length) return BattleshipStatus.Sunk;
                if (Hits.Count > 0) return BattleshipStatus.Hit;
                return BattleshipStatus.Unknown;
            }
        }
    }
}
