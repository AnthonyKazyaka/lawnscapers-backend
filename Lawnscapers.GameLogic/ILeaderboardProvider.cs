using Lawnscapers.Models;

namespace Lawnscapers.GameLogic
{
    public interface ILeaderboardProvider
    {
        Task<IEnumerable<ScoreEntry>> GetScoresByPuzzleId(Guid puzzleId);
        Task<IEnumerable<ScoreEntry>> GetScoresByPlayerId(Guid playerId);
        Task SubmitScore(ScoreEntry scoreEntry);
    }
}   