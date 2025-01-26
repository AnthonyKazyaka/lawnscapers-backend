using Lawnscapers.Models;

namespace Lawnscapers.Providers
{
    public interface IScoreProvider
    {
        Task<IEnumerable<Score>> GetAllScoresAsync();
        Task<IEnumerable<Score>> GetScoresByPuzzleIdAsync(Guid puzzleId);
        Task<IEnumerable<Score>> GetScoresByPlayerIdAsync(Guid playerId);
        Task SubmitScoreAsync(Score scoreEntry);
    }
}