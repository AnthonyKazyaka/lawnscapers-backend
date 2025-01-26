using Lawnscapers.Models;
using Lawnscapers.Providers;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ScoresController : ControllerBase
{
    private readonly IScoreProvider _scoreProvider;

    public ScoresController(IScoreProvider scoreProvider)
    {
        _scoreProvider = scoreProvider;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Score>>> GetScores()
    {
        var scores = await _scoreProvider.GetAllScoresAsync();
        return Ok(scores);
    }

    [HttpGet("puzzles/{puzzleId}")]
    public async Task<ActionResult<IEnumerable<Score>>> GetScores(Guid puzzleId)
    {
        var scores = await _scoreProvider.GetScoresByPuzzleIdAsync(puzzleId);
        return Ok(scores);
    }

    [HttpGet("players/{playerId}")]
    public async Task<ActionResult<IEnumerable<Score>>> GetScoresByPlayer(Guid playerId)
    {
        var scores = await _scoreProvider.GetScoresByPlayerIdAsync(playerId);
        if (!scores.Any())
        {
            return NotFound($"No scores found for player with ID {playerId}");
        }
        return Ok(scores);
    }

    [HttpPost]
    public async Task<IActionResult> SubmitScore(Score scoreEntry)
    {
        await _scoreProvider.SubmitScoreAsync(scoreEntry);
        return Ok();
    }
}
