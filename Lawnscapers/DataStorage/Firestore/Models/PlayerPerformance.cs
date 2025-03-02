using Google.Cloud.Firestore;

namespace Lawnscapers.DataStorage.Firestore.Models
{
    [FirestoreData]
    public class PlayerPerformance
    {
        [FirestoreDocumentId]
        public string Id { get; set; } = string.Empty;

        [FirestoreProperty("playerId")]
        public string PlayerId { get; set; } = string.Empty;

        [FirestoreProperty("puzzleId")]
        public string PuzzleId { get; set; } = string.Empty;

        [FirestoreProperty("score")]
        public int Score { get; set; }

        [FirestoreProperty("attemptedAt")]
        public DateTime AttemptedAt { get; set; } = DateTime.UtcNow;

        [FirestoreProperty("isBestScore")]
        public bool IsBestScore { get; set; }
    }
}
