using LeaderBoardAPI.Entities;
using LeaderBoardAPI.Repositories.Abstract;
using LeaderBoardAPI.Repositories.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LeaderBoardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LeagueController : ControllerBase
    {
        private readonly ILeagueRepo _leagueRepo;


        public LeagueController(ILeagueRepo leagueRepo)
        {
            _leagueRepo = leagueRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_leagueRepo.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _leagueRepo.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(League model)
        {
            await _leagueRepo.Add(new()
            {
                LeagueName = model.LeagueName,
            });

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update(League request)
        {
            League league = new()
            {
                Id = request.Id,
                LeagueName = request.LeagueName,
            };
            await _leagueRepo.Update(league);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _leagueRepo.Delete(id);
            return Ok();
        }
    }
}
