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
    public class BattleshipController : Controller
    {
        private readonly IBattleshipStore battleships;

        public BattleshipController(IBattleshipStore battleships)
        {
            this.battleships = battleships;
        }

        [HttpGet]
        [Route("api/boards/{board}/battleship/{battleship}", Name = NamedRoutes.GetBattleship)]
        [ProducesResponseType(200, Type = typeof(Battleship))]
        [ProducesResponseType(400)]
        public IActionResult Get(Guid board, Guid battleship)
        {
            var model = battleships.Get(board, battleship);

            if(model == null)
            {
                ModelState.AddModelError(nameof(battleship), $"Could not find battleship {battleship} on board {board}");
                return BadRequest(ModelState);
            }

            return Ok(model);
        }

        [HttpPost]
        [Route("api/boards/{board}/battleship/{battleship}/add")]
        [ProducesResponseType(200, Type = typeof(Battleship))]
        [ProducesResponseType(400)]
        public IActionResult AddBattleship(Guid board, Guid battleship, [FromBody]Location location)
        {
            var located = battleships.TryAdd(board, battleship, location, out Battleship model);

            if (model == null)
            {
                ModelState.AddModelError(nameof(battleship), $"Could not find battleship {battleship} on board {board}");
                return BadRequest(ModelState);
            }

            if (!located)
            {
                ModelState.AddModelError(nameof(location), $"{location.Column}{location.Row} is out of bounds, direction={location.Placement.ToString()}");
                return BadRequest(ModelState);
            }

            return Ok(model);
        }
    }
}
