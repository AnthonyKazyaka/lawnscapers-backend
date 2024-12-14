using Lawnscapers.GameLogic.DataStorage;
using Lawnscapers.Models;

namespace Lawnscapers.GameLogic
{
    public class LeaderboardProvider : ILeaderboardProvider
    {
        private readonly IRepository<ScoreEntry> _repository;

        public LeaderboardProvider(IRepository<ScoreEntry> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<ScoreEntry>> GetScoresByPuzzleId(Guid puzzleId)
        {
            var allScores = await _repository.GetAllAsync();
            if (allScores == null)
            {
                return Enumerable.Empty<ScoreEntry>();
            }

            return allScores
                .Where(score => score.PuzzleId == puzzleId)
                .OrderBy(score => score.Score); // Lower is better
        }


        public async Task<IEnumerable<ScoreEntry>> GetScoresByPlayerId(Guid userId)
        {
            var allScores = await _repository.GetAllAsync();
            return allScores
                .Where(score => score.Player.Id == userId)
                .OrderBy(score => score.Score);
        }

        public async Task SubmitScore(ScoreEntry scoreEntry)
        {
            var existingScores = await GetScoresByPuzzleId(scoreEntry.PuzzleId);
            var playerBestScore = existingScores.FirstOrDefault(s => s.Player.Id == scoreEntry.Player.Id);

            if (playerBestScore == null || scoreEntry.Score < playerBestScore.Score)
            {
                await _repository.AddAsync(scoreEntry);
            }
        }
    }
}
