namespace Lawnscapers.Models
{
    public class Puzzle
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Creator { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Position PlayerStartPosition { get; set; }
        public List<Position> Obstacles { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public Puzzle(Guid id, string name, string creator, int width, int height, Position playerStartPosition, List<Position> obstaclePositions, DateTime createdAt)
        {
            Id = id;
            Name = name;
            Creator = creator;
            Width = width;
            Height = height;
            PlayerStartPosition = playerStartPosition;
            Obstacles = obstaclePositions;
            CreatedAt = createdAt;
        }
    }
}