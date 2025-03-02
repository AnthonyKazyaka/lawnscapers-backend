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
        private readonly IScoreProvider _scoreProvider;

        public PuzzlesController(IPuzzleProvider puzzleProvider, IScoreProvider scoreProvider)
        {
            _puzzleProvider = puzzleProvider;
            _scoreProvider = scoreProvider;
        }

        [HttpGet]
        public async Task<ActionResult<IDictionary<string, IEnumerable<Puzzle>>>> GetPuzzles(int page = 1, int pageSize = 20)
        {
            var puzzles = await _puzzleProvider.GetAllPuzzlesAsync();

            return Ok(puzzles);
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
