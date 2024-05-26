using Lawnscapers.Models;

namespace Lawnscapers.GameLogic
{
    public interface ILeaderboardProvider
    {
        Task<IEnumerable<ScoreEntry>> GetScores(string puzzleId);
        Task SubmitScore(ScoreEntry scoreEntry);
    }
}