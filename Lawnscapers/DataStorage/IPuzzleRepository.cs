using Lawnscapers.DataStorage.Firestore.Models;

namespace Lawnscapers.DataStorage.Firestore
{
    public interface IPuzzleRepository : IRepository<Puzzle>
    {
        Task<IEnumerable<Puzzle>> GetPuzzlesByDifficultyAsync(string difficulty, CancellationToken cancellationToken = default);
    }
}
