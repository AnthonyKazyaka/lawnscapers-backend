namespace Lawnscapers.Models
{
    public class Score
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public Player Player { get; set; }
        public int Moves { get; set; }
        public string PuzzleId { get; set; }
        public DateTime Timestamp { get; set; }
        public string ScoreHash { get; set; }

        public Score(string id, string puzzleId, Player player, int moves, string scoreHash, DateTime timestamp)
        {
            Id = id;
            PuzzleId = puzzleId;
            Player = player;
            Moves = moves;
            ScoreHash = scoreHash;
            Timestamp = timestamp;
        }
    }
}
