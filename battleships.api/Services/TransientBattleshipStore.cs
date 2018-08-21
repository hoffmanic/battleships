using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using battleships.api.Models;

namespace battleships.api.Services
{
    public class TransientBattleshipStore : IBattleshipStore
    {
        private readonly IGameBoardStore boards;
        public TransientBattleshipStore(IGameBoardStore boards)
        {
            this.boards = boards;
        }

        public bool TryAdd(Guid board, Guid battleship, Location location, out Battleship model)
        {
            model = Get(board, battleship);

            if(model != null)
            {
                var (positions, inbounds) = model.ValidateLocation(location);
                if (inbounds)
                {
                    if (boards.Index(board, model, positions))
                    {
                        model.Location = location;
                        return true;
                    }
                }
            }

            return false;
        }

        public Battleship Get(Guid board, Guid battleship)
        {
            return boards.Get(board)
                ?.Battleships
                .FirstOrDefault(p => p.Id == battleship);
        }
    }
}
