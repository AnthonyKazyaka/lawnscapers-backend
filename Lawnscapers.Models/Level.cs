namespace Lawnscapers.Models
{
    public class Level
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Player Creator { get; set; }
        public Puzzle Puzzle { get; set; }
    }
}
