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
            try
            {
                return Ok(await _playerProvider.GetAllPlayersAsync());
            }
            catch (Exception)
            {
                return NotFound("No players found.");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(string id)
        {
            try
            {
                return Ok(await _playerProvider.GetPlayerAsync(id));
            }
            catch (Exception)
            {
                return NotFound($"Player with ID {id} not found.");
            }
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer(Player player)
        {
            try
            {
                return Ok(await _playerProvider.CreatePlayerAsync(player));
            }
            catch (Exception)
            {
                return BadRequest("Unable to create player.");
            }
        }

        [HttpPut]
        public async Task<IActionResult> UpdatePlayer(Player updatedPlayer)
        {
            var id = updatedPlayer.Id;

            try
            {
                await _playerProvider.UpdatePlayerAsync(updatedPlayer);
                return Ok();
            }
            catch (Exception)
            {
                return NotFound($"Player with ID {id} not found.");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(string id)
        {
            await _playerProvider.DeletePlayerAsync(id);
            return NoContent();
        }
    }
}
