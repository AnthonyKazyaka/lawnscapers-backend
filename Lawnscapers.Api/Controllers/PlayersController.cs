using Microsoft.AspNetCore.Mvc;
using Lawnscapers.Models;
using Lawnscapers.Providers;

namespace Lawnscapers.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerProvider _playerProvider;

        public PlayersController(IPlayerProvider playerProvider)
        {
            _playerProvider = playerProvider;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers()
        {
            var players = await _playerProvider.GetAllPlayersAsync();
            return Ok(players);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(Guid id)
        {
            var player = await _playerProvider.GetPlayerAsync(id);
            if (player == null)
            {
                return NotFound($"Player with ID {id} not found.");
            }
            return Ok(player);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer(Player player)
        {
            await _playerProvider.CreatePlayerAsync(player);
            return Ok(player);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayer(Guid id, Player updatedPlayer)
        {
            var existingPlayer = await _playerProvider.GetPlayerAsync(id);
            if (existingPlayer == null)
            {
                return NotFound($"Player with ID {id} not found.");
            }

            updatedPlayer.Id = id;
            await _playerProvider.UpdatePlayerAsync(updatedPlayer);

            return NoContent();
        }

        //[HttpDelete("{id}")]
        //public async Task<IActionResult> DeletePlayer(Guid id)
        //{
        //    var player = await _playerProvider.GetPlayerAsync(id);
        //    if (player == null)
        //    {
        //        return NotFound($"Player with ID {id} not found.");
        //    }

        //    await _playerProvider.DeletePlayerAsync(id);
        //    return NoContent();
        //}
    }
}
