using LeaderBoardAPI.Entities;
using LeaderBoardAPI.Repositories.Abstract;
using LeaderBoardAPI.Repositories.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LeaderBoardAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepo _userRepo;

        public UserController(IUserRepo userRepo)
        {
            _userRepo = userRepo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(_userRepo.GetAll().OrderByDescending(u => u.Score));
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _userRepo.Get(id));
        }

        [HttpPost]
        public async Task<IActionResult> Post(User model)
        {
            await _userRepo.Add(new()
            {
                Username = model.Username,
                Score = model.Score,
                LeagueId = model.LeagueId
            });

            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateUser(User request)
        {
            User User = new()
            {
                Id = request.Id,
                Username = request.Username,
                Score = request.Score,
                LeagueId = request.LeagueId
            };
            await _userRepo.Update(User);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await _userRepo.Delete(id);
            return Ok();
        }
    }
}
