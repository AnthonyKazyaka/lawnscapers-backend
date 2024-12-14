using Lawnscapers.GameLogic;
using Lawnscapers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lawnscapers.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LeaderboardsController : ControllerBase
    {
        private readonly ILeaderboardProvider _leaderboardProvider;

        public LeaderboardsController(ILeaderboardProvider leaderboardProvider)
        {
            _leaderboardProvider = leaderboardProvider;
        }

        [HttpGet("/puzzles/{puzzleId}")]
        public async Task<ActionResult<IEnumerable<ScoreEntry>>> GetScores(string puzzleId)
        {
            var scores = await _leaderboardProvider.GetScoresByPuzzleId(puzzleId);
            return Ok(scores);
        }



        [HttpPost]
        public async Task<IActionResult> SubmitScore(ScoreEntry scoreEntry)
        {
            await _leaderboardProvider.SubmitScore(scoreEntry);
            return Ok();
        }
    }
}
