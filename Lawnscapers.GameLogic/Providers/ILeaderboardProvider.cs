using Lawnscapers.Models;

namespace Lawnscapers.Providers
{
    public interface ILeaderboardProvider
    {
        Task<IEnumerable<ScoreEntry>> GetAllScoresAsync();
        Task<IEnumerable<ScoreEntry>> GetScoresByPuzzleIdAsync(Guid puzzleId);
        Task<IEnumerable<ScoreEntry>> GetScoresByPlayerIdAsync(Guid playerId);
        Task SubmitScoreAsync(ScoreEntry scoreEntry);
    }
}