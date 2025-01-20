using Lawnscapers.Models;
using Lawnscapers.Providers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class LeaderboardsController : ControllerBase
{
    private readonly ILeaderboardProvider _leaderboardProvider;

    public LeaderboardsController(ILeaderboardProvider leaderboardProvider)
    {
        _leaderboardProvider = leaderboardProvider;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<ScoreEntry>>> GetScores()
    {
        var scores = await _leaderboardProvider.GetAllScoresAsync();
        return Ok(scores);
    }

    [HttpGet("puzzles/{puzzleId}")]
    public async Task<ActionResult<IEnumerable<ScoreEntry>>> GetScores(Guid puzzleId)
    {
        var scores = await _leaderboardProvider.GetScoresByPuzzleIdAsync(puzzleId);
        return Ok(scores);
    }

    [HttpGet("players/{playerId}")]
    public async Task<ActionResult<IEnumerable<ScoreEntry>>> GetScoresByPlayer(Guid playerId)
    {
        var scores = await _leaderboardProvider.GetScoresByPlayerIdAsync(playerId);
        if (!scores.Any())
        {
            return NotFound($"No scores found for player with ID {playerId}");
        }
        return Ok(scores);
    }

    [HttpPost]
    public async Task<IActionResult> SubmitScore(ScoreEntry scoreEntry)
    {
        await _leaderboardProvider.SubmitScoreAsync(scoreEntry);
        return Ok();
    }
}
