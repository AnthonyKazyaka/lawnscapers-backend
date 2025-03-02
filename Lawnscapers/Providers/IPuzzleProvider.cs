using Lawnscapers.Enums;
using Lawnscapers.Models;

namespace Lawnscapers.Providers
{
    public interface IPuzzleProvider
    {
        Task<IDictionary<PuzzleType, IEnumerable<Puzzle>>> GetAllPuzzlesAsync();
        Task<IEnumerable<Puzzle>> GetPuzzlesByTypeAsync(PuzzleType puzzleType);
        Task<Puzzle> GetPuzzleAsync(Guid puzzleId);
        Task AddPuzzleAsync(Puzzle puzzle);
        Task UpdatePuzzleAsync(Puzzle puzzle);
        Task DeletePuzzleAsync(Guid puzzleId);
    }
}