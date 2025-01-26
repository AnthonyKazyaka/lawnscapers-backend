using Lawnscapers.DataStorage;
using Lawnscapers.DataStorage.Firestore;
using Lawnscapers.Models;

namespace Lawnscapers.Providers
{
    public class ScoreProvider : IScoreProvider
    {
        private readonly IScoreRepository _scoreRepository;
        private readonly IDataMapper<DataStorage.Firestore.Models.Score, Score> _scoreMapper;

        public ScoreProvider(IScoreRepository scoreRepository, IDataMapper<DataStorage.Firestore.Models.Score, Score> scoreMapper)
        {
            _scoreRepository = scoreRepository;
            _scoreMapper = scoreMapper;
        }

        public async Task<IEnumerable<Score>> GetAllScoresAsync()
        {
            var firestoreScoreEntries = await _scoreRepository.GetAllAsync();
            var scoreEntries = firestoreScoreEntries.Select(score => _scoreMapper.Map(score));

            return scoreEntries;
        }

        public async Task<IEnumerable<Score>> GetScoresByPuzzleIdAsync(Guid puzzleId)
        {
            var puzzleScores = await _scoreRepository.GetScoresByPuzzleIdAsync(puzzleId.ToString());
            if (puzzleScores == null)
            {
                return Enumerable.Empty<Score>();
            }

            var filteredScores = puzzleScores
                .Where(score => score.PuzzleId == puzzleId.ToString())
                .OrderBy(score => score.Moves); // Lower is better

            return filteredScores.Select(score => _scoreMapper.Map(score));
        }

        public async Task<IEnumerable<Score>> GetScoresByPlayerIdAsync(Guid playerId)
        {
            var playerScores = await _scoreRepository.GetScoresByPlayerIdAsync(playerId.ToString());
            if (playerScores == null)
            {
                return Enumerable.Empty<Score>();
            }

            var orderedScores = playerScores.OrderBy(score => score.ScoreHash);

            return orderedScores.Select(score => _scoreMapper.Map(score));
        }

        public async Task SubmitScoreAsync(Score scoreEntry)
        {
            var existingScores = await GetScoresByPuzzleIdAsync(scoreEntry.PuzzleId);
            var playerBestScore = existingScores.FirstOrDefault(s => s.Player.Id == scoreEntry.Player.Id);

            if (playerBestScore == null || scoreEntry.Moves < playerBestScore.Moves)
            {
                var mappedScoreEntry = _scoreMapper.Map(scoreEntry);

                await _scoreRepository.AddAsync(mappedScoreEntry);
            }
        }
    }
}
