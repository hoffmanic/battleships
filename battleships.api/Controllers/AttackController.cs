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
    public class AttackController : Controller
    {
        private readonly IAttackStore attacks;

        public AttackController(IAttackStore attacks)
        {
            this.attacks = attacks;
        }

        [HttpPost]
        [Route("api/boards/{board}/attack")]
        [ProducesResponseType(404)]
        [ProducesResponseType(410)]
        [ProducesResponseType(302)]
        [ProducesResponseType(400)]
        public IActionResult Post(Guid board, [FromBody]Coordinate attack)
        {
            var model = attacks.Attack(board, attack);

            if(model == null)
            {
                return NotFound();
            }

            if (attacks.GameOver(board))
            {
                return StatusCode(410);
            }

            return Redirect(Url.Link(NamedRoutes.GetBattleship, new { board, battleship = model.Id }));
        }
    }
}
