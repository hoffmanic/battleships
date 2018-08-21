using battleships.api.Models;
using battleships.api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace battleships.api.Controllers
{
    [Produces("application/json")]
    [ApiController]
    public class GameBoardController : Controller
    {
        private readonly IGameBoardStore boards;
 
        public GameBoardController(IGameBoardStore boards)
        {
            this.boards = boards;
        }

        [HttpGet]
        [Route("/api/boards/{board}", Name=NamedRoutes.GetBoard)]
        [ProducesResponseType(400)]
        [ProducesResponseType(200, Type=typeof(GameBoard))]
        public IActionResult Get(Guid board)
        {
            var model = boards.Get(board);
            if(model == null)
            {
                ModelState.AddModelError(nameof(board), $"Could not find board {board}");
                return BadRequest(ModelState);
            }
            return Ok(model);
        }

        [HttpPost]
        [Route("/api/boards")]
        [ProducesResponseType(201, Type = typeof(GameBoard))]
        public IActionResult Post()
        {
            var board = new GameBoard
            {
                Battleships = new List<Battleship>()
                {
                    new Battleship{ Length = 4 },
                },
            };

            boards.Add(board);

            return Created(Url.Link(NamedRoutes.GetBoard, new { board = board.Id }), board);
        }
    }
}
