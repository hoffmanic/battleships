using battleships.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace battleships.api.Services
{
    public interface IBattleshipStore
    {
        Battleship Get(Guid board, Guid battleship);
        bool TryAdd(Guid board, Guid battleship, Location location, out Battleship model);
    }
}
