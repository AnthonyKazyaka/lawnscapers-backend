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

        public PuzzlesController(IPuzzleRepository puzzleRepository)
        {
            _puzzleRepository = puzzleRepository;
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

        [HttpPost]
        public async Task<IActionResult> CreatePuzzle(Puzzle puzzle)
        {
            await _puzzleRepository.SavePuzzle(puzzle);
            return Ok();
        }
    }
}
