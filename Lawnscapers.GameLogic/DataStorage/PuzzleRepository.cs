using Lawnscapers.Models;

namespace Lawnscapers.GameLogic.DataStorage
{
    public class PuzzleRepository : IPuzzleRepository
    {
        private readonly IDatabaseService<Puzzle> _puzzleDatabaseService;

        public PuzzleRepository(IDatabaseService<Puzzle> puzzleDatabaseService)
        {
            _puzzleDatabaseService = puzzleDatabaseService;
        }

        public async Task<IEnumerable<Puzzle>> GetOfficialPuzzlesData()
        {
            return await _puzzleDatabaseService.GetData("officialPuzzles");
        }

        public async Task<IEnumerable<Puzzle>> GetSubmittedPuzzlesData()
        {
            return await _puzzleDatabaseService.GetData("submittedPuzzles");
        }

        public async Task SavePuzzle(Puzzle puzzleData)
        {
            await _puzzleDatabaseService.SubmitData(puzzleData.Id.ToString(), puzzleData);
        }
    }
}
