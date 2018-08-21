using battleships.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace battleships.api.Services
{
    public static class GameBoardCalculations
    {
        public static (Coordinate[] positions, bool inbounds) ValidateLocation(this Battleship source, Location location, char maxCols = 'J', int maxRows = 10)
        {
            const char minCol = 'A';
            const int minRow = 1;

            var positions = new Coordinate[0];

            if(location.Placement == Direction.EastWest)
            {
                positions = Enumerable
                    .Range(location.Column, source.Length)
                    .Select(column => new Coordinate { Row = location.Row, Column = (char)column })
                    .ToArray();
            }

            if(location.Placement == Direction.NorthSouth)
            {
                positions = Enumerable
                    .Range(location.Row, source.Length)
                    .Select(row => new Coordinate { Column = location.Column, Row = row })
                    .ToArray();
            }

            if(positions.Any(p => p.Row < minRow || p.Column < minCol || p.Row > maxRows || p.Column > maxCols))
            {
                return (null, false);
            }

            return (positions, true);
        }
    }
}
