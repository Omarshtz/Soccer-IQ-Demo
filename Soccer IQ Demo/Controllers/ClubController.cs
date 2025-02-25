using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Soccer_IQ_Demo.Models;
using Soccer_IQ_Demo.Repository;

namespace Soccer_IQ_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClubController : ControllerBase
    {


        ClubRepository clubRepository = new ClubRepository();
        public IActionResult Display()
        {

            var Clubs = clubRepository.GetAll();
            return Ok(Clubs);





        }
        public IActionResult Create(Club club)
        {
            if (ModelState.IsValid)
            {
                clubRepository.Add(club);
                clubRepository.Commit();

                return BadRequest();
            }
            return Ok(club);

        }
        public IActionResult Edit(Club club)
        {
            clubRepository.Edit(club);
            clubRepository.Commit();
            return Ok();
        }
        public IActionResult Delete(int clubId)
        {
            var club = clubRepository.GetById(clubId);

            clubRepository.Delete(club);
            clubRepository.Commit();
            return Ok();
        }

































        }
    }
