using Lawnscapers.Models;
using Lawnscapers.GameLogic.DataStorage;
using Microsoft.AspNetCore.Mvc;

namespace Lawnscapers.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PlayerController : ControllerBase
    {
        private readonly IRepository<Player> _playerRepository;

        public PlayerController(IRepository<Player> playerRepository)
        {
            _playerRepository = playerRepository;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Player>> GetPlayer(Guid id)
        {
            var player = await _playerRepository.GetByIdAsync(id);
            if (player == null)
            {
                return NotFound($"Player with ID {id} not found.");
            }
            return Ok(player);
        }

        [HttpPost]
        public async Task<IActionResult> CreatePlayer(Player player)
        {
            await _playerRepository.AddAsync(player);
            return CreatedAtAction(nameof(GetPlayer), new { id = player.Id }, player);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdatePlayer(Guid id, Player updatedPlayer)
        {
            var existingPlayer = await _playerRepository.GetByIdAsync(id);
            if (existingPlayer == null)
            {
                return NotFound($"Player with ID {id} not found.");
            }

            updatedPlayer.Id = id;
            await _playerRepository.UpdateAsync(updatedPlayer);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePlayer(Guid id)
        {
            var player = await _playerRepository.GetByIdAsync(id);
            if (player == null)
            {
                return NotFound($"Player with ID {id} not found.");
            }

            await _playerRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
