using Lawnscapers.GameLogic;
using Lawnscapers.GameLogic.DataStorage;
using Lawnscapers.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lawnscapers.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PuzzlesController : ControllerBase
    {
        private readonly IPuzzleRepository _puzzleRepository;
        private readonly ILeaderboardProvider _leaderboardProvider;

        public PuzzlesController(IPuzzleRepository puzzleRepository, ILeaderboardProvider leaderboardProvider)
        {
            _puzzleRepository = puzzleRepository;
            _leaderboardProvider = leaderboardProvider;
        }

        [HttpGet]
        public async Task<ActionResult<IDictionary<string, IEnumerable<Puzzle>>>> GetPuzzles()
        {
            var officialPuzzles = await _puzzleRepository.GetOfficialPuzzlesData();
            var communityPuzzles = await _puzzleRepository.GetSubmittedPuzzlesData();
            
            var puzzles = new Dictionary<string, IEnumerable<Puzzle>>
            {
                { "official", officialPuzzles },
                { "community", communityPuzzles }
            };

            return Ok(puzzles);
        }

        [HttpGet]
        [Route("{puzzleId}/leaderboards")]
        public async Task<ActionResult<IEnumerable<ScoreEntry>>> GetScoresByPuzzleId(string puzzleId)
        {
            var scores = await _leaderboardProvider.GetScoresByPuzzleId(puzzleId);
            return Ok(scores);
        }


        [HttpPost]
        public async Task<IActionResult> CreatePuzzle(Puzzle puzzle)
        {
            await _puzzleRepository.SavePuzzle(puzzle);
            return Ok();
        }
    }
}
