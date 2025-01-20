using Lawnscapers.Enums;
using Lawnscapers.Models;
using Lawnscapers.Providers;
using Microsoft.AspNetCore.Mvc;

namespace Lawnscapers.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PuzzlesController : ControllerBase
    {
        private readonly IPuzzleProvider _puzzleProvider;
        private readonly ILeaderboardProvider _leaderboardProvider;

        public PuzzlesController(IPuzzleProvider puzzleProvider, ILeaderboardProvider leaderboardProvider)
        {
            _puzzleProvider = puzzleProvider;
            _leaderboardProvider = leaderboardProvider;
        }

        [HttpGet]
        public async Task<ActionResult<IDictionary<string, IEnumerable<Puzzle>>>> GetPuzzles(int page = 1, int pageSize = 20)
        {
            var puzzles = await _puzzleProvider.GetAllPuzzlesAsync();

            return Ok(puzzles);
        }

        [HttpGet]
        [Route("{puzzleId}/leaderboards")]
        public async Task<ActionResult<IEnumerable<ScoreEntry>>> GetScoresByPuzzleId(Guid puzzleId)
        {
            var scores = await _leaderboardProvider.GetScoresByPuzzleIdAsync(puzzleId);
            return Ok(scores);
        }


        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreatePuzzle([FromBody] Puzzle puzzle)
        {
            await _puzzleProvider.AddPuzzleAsync(puzzle);
            return Ok();
        }
    }
}
