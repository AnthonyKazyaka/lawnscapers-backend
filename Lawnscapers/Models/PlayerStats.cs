namespace Lawnscapers.Models
{
    public class PlayerStats
    {
        public Guid PlayerId { get; set; }
        public int PuzzlesCreated { get; set; }
        public int TotalPuzzlesPlayed { get; set; }
        public int UniquePuzzlesPlayed { get; set; }
        public int UniquePuzzlesSolved { get; set; }
        public int TotalMoves { get; set; }
    }
}
