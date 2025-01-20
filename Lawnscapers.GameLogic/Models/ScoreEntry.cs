namespace Lawnscapers.Models
{
    public class ScoreEntry
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Player Player { get; set; }
        public int Score { get; set; }
        public Guid PuzzleId { get; set; }
        public DateTime Timestamp { get; set; }

        public ScoreEntry(Guid id, Player player, int score, Guid puzzleId, DateTime timestamp)
        {
            Id = id;
            Player = player;
            Score = score;
            PuzzleId = puzzleId;
            Timestamp = timestamp;
        }
    }
}
