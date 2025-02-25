using Microsoft.AspNetCore.Mvc;
using Soccer_IQ_Demo.Models;
using Soccer_IQ_Demo.Repository;

namespace Soccer_IQ_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {
        private readonly ClubRepository clubRepository;

        public ClubController(ClubRepository clubRepository)
        {
            this.clubRepository = clubRepository;
        }

        [HttpGet]
        public IActionResult Display()
        {
            var clubs = clubRepository.GetAll();
            return Ok(clubs);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Club club)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            clubRepository.Add(club);
            return CreatedAtAction(nameof(Display), new { id = club.Id }, club);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Club club)
        {
            var existingClub = clubRepository.GetById(club.Id);
            if (existingClub == null)
            {
                return NotFound("Club not found");
            }

            clubRepository.Edit(club);
            return Ok(club);
        }

        [HttpDelete("{clubId}")]
        public IActionResult Delete(int clubId)
        {
            var club = clubRepository.GetById(clubId);
            if (club == null)
            {
                return NotFound("Club not found");
            }

            clubRepository.Delete(club);
            return NoContent();
        }
    }
}
