using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using battleships.api.Models;

namespace battleships.api.Services
{
    public class TransientAttackStore : IAttackStore
    {
        private readonly IGameBoardStore boards;

        public TransientAttackStore(IGameBoardStore boards)
        {
            this.boards = boards;
        }

        public Battleship Attack(Guid board, Coordinate attack)
        {
            var battleship = boards.Seek(board, attack);
            if(battleship != null)
            {
                battleship.Hits.Add(attack);
            }
            return battleship;
        }

        public bool GameOver(Guid board)
        {
            var model = boards.Get(board);

            return model.Battleships.All(p => p.Status == BattleshipStatus.Sunk);
        }
    }
}
