using Google.Cloud.Firestore;

namespace Lawnscapers.DataStorage.Firestore.Models
{
    [FirestoreData]
    public class Score
    {
        [FirestoreDocumentId]
        public string Id { get; set; } = string.Empty;

        [FirestoreProperty("playerId")]
        public string PlayerId { get; set; } = string.Empty;

        [FirestoreProperty("moves")]
        public int Moves { get; set; }

        [FirestoreProperty("puzzleId")]
        public string PuzzleId { get; set; } = string.Empty;

        [FirestoreProperty("timestamp")]
        public DateTime Timestamp { get; set; } = DateTime.UtcNow;

        [FirestoreProperty("scoreHash")]
        public string ScoreHash { get; set; } = string.Empty;
    }
}
