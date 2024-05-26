using Lawnscapers.Models;

namespace Lawnscapers.GameLogic.DataStorage
{
    public interface IPuzzleRepository
    {
        Task<IEnumerable<Puzzle>> GetOfficialPuzzlesData();
        Task<IEnumerable<Puzzle>> GetSubmittedPuzzlesData();
        Task SavePuzzle(Puzzle puzzleData);
    }
}