using Lawnscapers.Enums;

namespace Lawnscapers.Models
{
    public class Obstacle
    {
        public ObstacleType Type { get; set; }
        public Position Position { get; set; }

        public Obstacle(ObstacleType type, Position position)
        {
            Type = type;
            Position = position;
        }
    }
}
