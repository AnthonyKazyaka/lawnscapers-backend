using Lawnscapers.DataStorage;

namespace Lawnscapers.Providers
{
    public class LeaderboardProvider : ILeaderboardProvider
    {
        private readonly IRepository<DataStorage.Firestore.Models.ScoreEntry> _repository;

        public LeaderboardProvider(IRepository<DataStorage.Firestore.Models.ScoreEntry> repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Lawnscapers.Models.ScoreEntry>> GetAllScoresAsync()
        {
            var firestoreScoreEntries = await _repository.GetAllAsync("leaderboards");
            var scoreEntries = firestoreScoreEntries.Select(score => Map(score));

            return scoreEntries;
        }

        public async Task<IEnumerable<Lawnscapers.Models.ScoreEntry>> GetScoresByPuzzleIdAsync(Guid puzzleId)
        {
            var allScores = await _repository.GetAllAsync($"puzzles/{puzzleId}/scores");
            if (allScores == null)
            {
                return Enumerable.Empty<Lawnscapers.Models.ScoreEntry>();
            }

            var filteredScores = allScores
                .Where(score => score.PuzzleId == puzzleId.ToString())
                .OrderBy(score => score.Score); // Lower is better

            return filteredScores.Select(score => Map(score));
        }

        public async Task<IEnumerable<Lawnscapers.Models.ScoreEntry>> GetScoresByPlayerIdAsync(Guid playerId)
        {
            var allScores = await _repository.GetAllAsync($"players/{playerId}/scores");
            if (allScores == null)
            {
                return Enumerable.Empty<Lawnscapers.Models.ScoreEntry>();
            }

            var orderedScores = allScores.OrderBy(score => score.ScoreHash);

            return orderedScores.Select(score => Map(score));
        }

        public async Task SubmitScoreAsync(Lawnscapers.Models. ScoreEntry scoreEntry)
        {
            var existingScores = await GetScoresByPuzzleIdAsync(scoreEntry.PuzzleId);
            var playerBestScore = existingScores.FirstOrDefault(s => s.Player.Id == scoreEntry.Player.Id);

            if (playerBestScore == null || scoreEntry.Score < playerBestScore.Score)
            {
                var mappedScoreEntry = Map(scoreEntry);

                await _repository.AddAsync(mappedScoreEntry, $"leaderboards/{scoreEntry.PuzzleId}");
                await _repository.AddAsync(mappedScoreEntry, $"players/{scoreEntry.Player.Id}/scores");
                await _repository.AddAsync(mappedScoreEntry, $"players/{scoreEntry.Player.Id}/playedPuzzles/{scoreEntry.PuzzleId}/scores");
                await _repository.AddAsync(mappedScoreEntry, $"puzzles/{scoreEntry.PuzzleId}/scores");
            }
        }

        private IEnumerable<Guid> GetPlayerIdsFromScoreEntries(IEnumerable<DataStorage.Firestore.Models.ScoreEntry> scoreEntries)
        {
            return scoreEntries
                .Where(x => !string.IsNullOrWhiteSpace(x.PlayerId))
                .Select(score => Guid.Parse(score.PlayerId!));
        }

        private static Models.ScoreEntry Map(DataStorage.Firestore.Models.ScoreEntry score)
        {
            return new Lawnscapers.Models.ScoreEntry(
                !string.IsNullOrWhiteSpace(score.Id) ? Guid.Parse(score.Id) : Guid.NewGuid(),
                new Lawnscapers.Models.Player
                {
                    Id = !string.IsNullOrWhiteSpace(score.PlayerId) ? Guid.Parse(score.PlayerId) : Guid.NewGuid(),
                    Name = score.PlayerName ?? string.Empty
                },
                score.Score,
                Guid.Parse(score.PuzzleId!),
                score.Timestamp
            );
        }

        private static DataStorage.Firestore.Models.ScoreEntry Map(Lawnscapers.Models.ScoreEntry score)
        {
            return new DataStorage.Firestore.Models.ScoreEntry
            {
                Id = score.Id.ToString(),
                PlayerId = score.Player.Id.ToString(),
                PlayerName = score.Player.Name,
                Score = score.Score,
                PuzzleId = score.PuzzleId.ToString(),
                Timestamp = score.Timestamp
            };
        }
    }
}
