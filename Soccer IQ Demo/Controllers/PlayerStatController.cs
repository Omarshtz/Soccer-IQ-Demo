using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Soccer_IQ_Demo.Models;
using Soccer_IQ_Demo.Repository;

namespace Soccer_IQ_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlayerStatController : ControllerBase
    {

        PlayerStatRepository playerStatRepository=new PlayerStatRepository();
        public IActionResult Display()
        {

            var playerstats = playerStatRepository.GetAll();
            return Ok(playerstats);





        }
        public IActionResult Create(PlayerStat playerStat)
        {
            if (ModelState.IsValid)
            {
                playerStatRepository.Add(playerStat);
                playerStatRepository.Commit();

                return BadRequest();
            }
            return Ok(playerStat);

        }
        public IActionResult Edit(PlayerStat playerStat)
        {
            playerStatRepository.Edit(playerStat);
            playerStatRepository.Commit();
            return Ok();
        }
        public IActionResult Delete(int playerStatId)
        {
            var playerStat = playerStatRepository.GetById(playerStatId);

            playerStatRepository.Delete(playerStat);
            playerStatRepository.Commit();
            return Ok();
        }


    }
}
