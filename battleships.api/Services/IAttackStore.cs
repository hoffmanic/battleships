using battleships.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace battleships.api.Services
{
    public interface IAttackStore
    {
        Battleship Attack(Guid board, Coordinate attack);
        bool GameOver(Guid board);
    }
}
