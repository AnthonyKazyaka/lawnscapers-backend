using Lawnscapers.Models;

namespace Lawnscapers.GameLogic
{
    public interface ILeaderboardProvider
    {
        Task<IEnumerable<ScoreEntry>> GetScoresByPuzzleId(string puzzleId);
        Task<IEnumerable<ScoreEntry>> GetScoresByUserId(string userId);
        Task SubmitScore(ScoreEntry scoreEntry);
    }
}