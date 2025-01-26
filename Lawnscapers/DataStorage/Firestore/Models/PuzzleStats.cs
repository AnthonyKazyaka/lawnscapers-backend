using Google.Cloud.Firestore;

namespace Lawnscapers.DataStorage.Firestore.Models
{
    [FirestoreData]
    public class PuzzleStats
    {
        [FirestoreProperty("bestScore")]
        public int BestScore { get; set; }

        [FirestoreProperty("attempts")]
        public int Attempts { get; set; }

        [FirestoreProperty("lastAttempt")]
        public DateTime LastAttempt { get; set; }
    }
}
