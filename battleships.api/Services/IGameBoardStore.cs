using battleships.api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace battleships.api.Services
{
    public interface IGameBoardStore
    {
        void Add(GameBoard board);
        GameBoard Get(Guid board);
        bool Index(Guid board, Battleship battleship, Coordinate[] positions);
        Battleship Seek(Guid board, Coordinate position);
    }
}
