using Lawnscapers.Models;

namespace Lawnscapers.Providers
{
    public interface IScoreProvider
    {
        Task<IEnumerable<Score>> GetAllScoresAsync();
        Task<IEnumerable<Score>> GetScoresByPuzzleIdAsync(string puzzleId);
        Task<IEnumerable<Score>> GetScoresByPlayerIdAsync(string playerId);
        Task SubmitScoreAsync(Score scoreEntry);
    }
}