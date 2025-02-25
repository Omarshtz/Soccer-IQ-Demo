using Microsoft.AspNetCore.Mvc;
using Soccer_IQ_Demo.Models;
using Soccer_IQ_Demo.Repository;

namespace Soccer_IQ_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {
        private readonly PlayerRepository playerRepository;

        public PlayerController(PlayerRepository playerRepository)
        {
            this.playerRepository = playerRepository;
        }

        [HttpGet]
        public IActionResult Display()
        {
            var players = playerRepository.GetAll();
            return Ok(players);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Player player)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            playerRepository.Add(player);
            return CreatedAtAction(nameof(Display), new { id = player.Id }, player);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Player player)
        {
            var existingPlayer = playerRepository.GetById(player.Id);
            if (existingPlayer == null)
            {
                return NotFound("Player not found");
            }

            playerRepository.Edit(player);
            return Ok(player);
        }

        [HttpDelete("{playerId}")]
        public IActionResult Delete(int playerId)
        {
            var player = playerRepository.GetById(playerId);
            if (player == null)
            {
                return NotFound("Player not found");
            }

            playerRepository.Delete(player);
            return NoContent();
        }
    }
}
