using Lawnscapers.DataStorage.Firestore.Models;

namespace Lawnscapers.DataStorage.Firestore
{
    public interface IScoreRepository : IRepository<Score>
    {
        Task<IEnumerable<Score>> GetScoresByPuzzleIdAsync(string puzzleId, CancellationToken cancellationToken = default);
        Task<IEnumerable<Score>> GetScoresByPlayerIdAsync(string playerId, CancellationToken cancellationToken = default);
    }
}
