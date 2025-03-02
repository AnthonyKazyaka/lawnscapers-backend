namespace Lawnscapers.DataStorage.Firestore
{
    public class ScoreMapper : IDataMapper<DataStorage.Firestore.Models.Score, Lawnscapers.Models.Score>
    {
        public Lawnscapers.Models.Score Map(DataStorage.Firestore.Models.Score data)
        {
            var score = new Lawnscapers.Models.Score(
                data.Id,
                data.PuzzleId,
                new Lawnscapers.Models.Player
                {
                    Id = data.PlayerId
                },
                data.Moves,
                data.ScoreHash,
                data.Timestamp
            );

            return score;
        }

        public DataStorage.Firestore.Models.Score Map(Lawnscapers.Models.Score data)
        {
            var utcTimestamp = new DateTimeOffset(data.Timestamp).UtcDateTime;

            var score = new DataStorage.Firestore.Models.Score
            {
                Id = data.Id.ToString(),
                PlayerId = data.Player.Id.ToString(),
                Moves = data.Moves,
                PuzzleId = data.PuzzleId.ToString(),
                Timestamp = utcTimestamp,
                ScoreHash = ComputeScoreHash(
                    data.PuzzleId.ToString(), data.Moves, data.Timestamp)
            };

            return score;
        }

        private static string ComputeScoreHash(string puzzleId, int score, DateTime timestamp)
        {
            return $"{puzzleId}_{score}_{timestamp:O}";
        }
    }
}