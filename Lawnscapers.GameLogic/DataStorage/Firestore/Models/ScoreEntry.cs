using Google.Cloud.Firestore;

namespace Lawnscapers.DataStorage.Firestore.Models
{
    [FirestoreData]
    public class ScoreEntry
    {
        [FirestoreDocumentId()]
        public string? Id { get; set; }

        [FirestoreProperty("playerId")]
        public string? PlayerId { get; set; }

        [FirestoreProperty("playerName")]
        public string? PlayerName { get; set; }

        [FirestoreProperty("score")]
        public int Score { get; set; }

        [FirestoreProperty("puzzleId_score_timestamp")]
        public string? ScoreHash { get; set; }

        [FirestoreProperty("puzzleId")]
        public string? PuzzleId { get; set; }

        [FirestoreProperty("timestamp")]
        public DateTime Timestamp { get; set; }
    }
}
