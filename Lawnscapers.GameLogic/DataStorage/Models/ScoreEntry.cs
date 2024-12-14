using Google.Cloud.Firestore;

namespace Lawnscapers.GameLogic.DataStorage.Models
{
    public class ScoreEntry
    {
        [FirestoreProperty]
        public string PlayerName { get; set; }

        [FirestoreProperty]
        public int Score { get; set; }

        [FirestoreProperty]
        public Guid PuzzleId { get; set; }

        [FirestoreProperty]
        public string Timestamp { get; set; }

        public ScoreEntry(string playerName, int score, Guid puzzleId, string timestamp)
        {
            PlayerName = playerName;
            Score = score;
            PuzzleId = puzzleId;
            Timestamp = timestamp;
        }

        public ScoreEntry(Lawnscapers.Models.ScoreEntry scoreEntry)
        {
            PlayerName = scoreEntry.Player.Name;
            Score = scoreEntry.Score;
            PuzzleId = scoreEntry.PuzzleId;
            Timestamp = scoreEntry.Timestamp;
        }
    }

}
