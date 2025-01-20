namespace Lawnscapers.DataStorage.Firestore
{
    public class ScoreEntryMapper : IDataMapper<DataStorage.Firestore.Models.ScoreEntry, Lawnscapers.Models.ScoreEntry>
    {
        public Lawnscapers.Models.ScoreEntry Map(DataStorage.Firestore.Models.ScoreEntry data)
        {
            var score = new Lawnscapers.Models.ScoreEntry(
                Guid.Parse(data.Id),
                new Lawnscapers.Models.Player
                {
                    Id = Guid.Parse(data.PlayerId),
                    Name = data.PlayerName
                },
                data.Score,
                Guid.Parse(data.PuzzleId),
                data.Timestamp
            );

            return score;
        }

        public DataStorage.Firestore.Models.ScoreEntry Map(Lawnscapers.Models.ScoreEntry data)
        {
            var score = new DataStorage.Firestore.Models.ScoreEntry
            {
                Id = data.Id.ToString(),
                PlayerId = data.Player.Id.ToString(),
                PlayerName = data.Player.Name,
                Score = data.Score,
                PuzzleId = data.PuzzleId.ToString(),
                Timestamp = data.Timestamp,
                ScoreHash = ComputeScoreHash(
                    data.PuzzleId.ToString(), data.Score, data.Timestamp)
            };

            return score;
        }

        private static string ComputeScoreHash(string puzzleId, int score, DateTime timestamp)
        {
            return $"{puzzleId}_{score}_{timestamp:O}";
        }
    }
}