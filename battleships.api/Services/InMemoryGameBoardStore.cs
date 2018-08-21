using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using battleships.api.Models;

namespace battleships.api.Services
{
    public class InMemoryGameBoardStore : IGameBoardStore
    {
        private List<GameBoard> boards = new List<GameBoard>();
        private Dictionary<string, Battleship> index = new Dictionary<string, Battleship>();

        public void Add(GameBoard board)
        {
            boards.Add(board);
        }

        public GameBoard Get(Guid board)
        {
            return boards.FirstOrDefault(p => p.Id == board);
        }

        public bool Index(Guid board, Battleship battleship, Coordinate[] positions)
        {
            var keys = positions.Select(position => CreateKey(board, position));

            if (keys.Any(key => index.ContainsKey(key)))
            {
                return false;
            }

            foreach (var key in keys)
            {
                index.Add(key, battleship);
            }
            return true;
        }

        public Battleship Seek(Guid board, Coordinate position)
        {
            var key = CreateKey(board, position);
            if (index.ContainsKey(key))
            {
                return index[key];
            }
            return null;
        }

        private string CreateKey(Guid board, Coordinate position)
        {
            return $"{board}-{position.Column}{position.Row}";
        }
    }
}
