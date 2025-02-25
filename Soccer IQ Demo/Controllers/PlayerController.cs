using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Soccer_IQ_Demo.Models;
using Soccer_IQ_Demo.Repository;

namespace Soccer_IQ_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerController : ControllerBase
    {

        PlayerRepository playerRepository=new PlayerRepository();
        public IActionResult Display()
        {

            var players = playerRepository.GetAll();
            return Ok(players);





        }
        public IActionResult Create(Player player)
        {
            if (ModelState.IsValid)
            {
                playerRepository.Add(player);
                playerRepository.Commit();

                return BadRequest();
            }
            return Ok(player);

        }
        public IActionResult Edit(Player player)
        {
            playerRepository.Edit(player);
            playerRepository.Commit();
            return Ok();
        }
        public IActionResult Delete(int playerId)
        {
            var player = playerRepository.GetById(playerId);

            playerRepository.Delete(player);
            playerRepository.Commit();
            return Ok();
        }

    }
}
