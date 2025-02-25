using Microsoft.AspNetCore.Mvc;
using Soccer_IQ_Demo.Models;
using Soccer_IQ_Demo.Repository;

namespace Soccer_IQ_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerStatController : ControllerBase
    {
        private readonly PlayerStatRepository playerStatRepository;

        public PlayerStatController(PlayerStatRepository playerStatRepository)
        {
            this.playerStatRepository = playerStatRepository;
        }

        [HttpGet]
        public IActionResult Display()
        {
            var playerStats = playerStatRepository.GetAll();
            return Ok(playerStats);
        }

        [HttpPost]
        public IActionResult Create([FromBody] PlayerStat playerStat)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            playerStatRepository.Add(playerStat);
            return CreatedAtAction(nameof(Display), new { id = playerStat.Id }, playerStat);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] PlayerStat playerStat)
        {
            var existingStat = playerStatRepository.GetById(playerStat.Id);
            if (existingStat == null)
            {
                return NotFound("PlayerStat not found");
            }

            playerStatRepository.Edit(playerStat);
            return Ok(playerStat);
        }

        [HttpDelete("{playerStatId}")]
        public IActionResult Delete(int playerStatId)
        {
            var playerStat = playerStatRepository.GetById(playerStatId);
            if (playerStat == null)
            {
                return NotFound("PlayerStat not found");
            }

            playerStatRepository.Delete(playerStat);
            return NoContent();
        }
    }
}
