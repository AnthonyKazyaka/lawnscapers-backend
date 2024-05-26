using Google.Cloud.Firestore;

namespace Lawnscapers.Models
{
    public class ScoreEntry
    {
        public string PlayerName { get; set; }
        public int Score { get; set; }
        public string PuzzleId { get; set; }
        public string Timestamp { get; set; }

        public ScoreEntry(string playerName, int score, string puzzleId, string timestamp)
        {
            PlayerName = playerName;
            Score = score;
            PuzzleId = puzzleId;
            Timestamp = timestamp;
        }
    }

}
