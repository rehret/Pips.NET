using Microsoft.AspNetCore.Mvc;
using Pips.Models;

namespace Pips.Controllers
{
    public class PipsController : Controller
    {
        [HttpGet("{d20string}")]
        [ProducesResponseType(typeof(PipsResponse), 200)]
        [ProducesResponseType(400)]
        public IActionResult GetDiceRoll([FromRoute] string d20string)
        {
            D20 d20;
            try
            {
                d20 = new D20(d20string);
            }
            catch
            {
                return BadRequest();
            }

            return Ok(new PipsResponse { Request = d20string, Rolls = d20.Rolls });
        }
    }
}
