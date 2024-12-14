using Lawnscapers.GameLogic.DataStorage;
using Lawnscapers.Models;

namespace Lawnscapers.GameLogic
{
    public class LeaderboardProvider : ILeaderboardProvider
    {
        private readonly IScoreRepository _scoreRepository;

        public LeaderboardProvider(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }

        public async Task<IEnumerable<ScoreEntry>> GetScoresByPuzzleId(string puzzleId)
        {
            var scores = await _scoreRepository.Get(puzzleId);
            return scores.Select(MapToModelScoreEntry);
        }

        public async Task<IEnumerable<ScoreEntry>> GetScoresByUserId(string userId)
        {
            var allScores = await _scoreRepository.Get();
            return allScores.Values.SelectMany(scores => scores)
                .Where(score => score.PlayerName == userId)
                .Select(MapToModelScoreEntry);
        }

        public async Task SubmitScore(ScoreEntry scoreEntry)
        {
            var score = MapToDataStorageScoreEntry(scoreEntry);
            await _scoreRepository.Submit(score);
        }

        private static ScoreEntry MapToModelScoreEntry(DataStorage.Models.ScoreEntry score)
        {
            return new ScoreEntry(score.PlayerName, score.Score, score.PuzzleId, score.Timestamp);
        }

        private static DataStorage.Models.ScoreEntry MapToDataStorageScoreEntry(ScoreEntry scoreEntry)
        {
            return new DataStorage.Models.ScoreEntry(scoreEntry);
        }
    }
}
