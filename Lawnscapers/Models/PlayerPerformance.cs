namespace Lawnscapers.Models
{
    public class PlayerPerformance
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PlayerId { get; set; } // Foreign key to Player
        public Guid PuzzleId { get; set; } // Foreign key to Puzzle
        public int Score { get; set; } // The player's score for this puzzle
        public DateTime AttemptedAt { get; set; } = DateTime.UtcNow; // When this score was recorded
        public bool IsBestScore { get; set; } // Whether this is the player's best score for this puzzle
    }

}