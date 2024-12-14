using Google.Cloud.Firestore;

namespace Lawnscapers.Models
{
    public class ScoreEntry
    {
        public Player Player { get; set; }
        public int Score { get; set; }
        public Guid PuzzleId { get; set; }
        public string Timestamp { get; set; }

        public ScoreEntry(Player player, int score, Guid puzzleId, string timestamp)
        {
            Player = player;
            Score = score;
            PuzzleId = puzzleId;
            Timestamp = timestamp;
        }
    }
}
