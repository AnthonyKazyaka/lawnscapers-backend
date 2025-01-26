namespace Lawnscapers.DataStorage.Firestore
{
    public class PuzzleMapper : IDataMapper<DataStorage.Firestore.Models.Puzzle, Lawnscapers.Models.Puzzle>
    {
        public Lawnscapers.Models.Puzzle Map(DataStorage.Firestore.Models.Puzzle data)
        {
            var puzzle = new Lawnscapers.Models.Puzzle(
                Guid.Parse(data.Id),
                data.Name,
                new Lawnscapers.Models.Player { Name = data.Creator },
                data.Width,
                data.Height,
                new Lawnscapers.Models.Position(data.PlayerStartPosition.X, data.PlayerStartPosition.Y),
                data.Obstacles?.Select(o => new Lawnscapers.Models.Obstacle(Enums.ObstacleType.Wall, new Lawnscapers.Models.Position(o.Position.X, o.Position.Y))).ToList() ?? new List<Lawnscapers.Models.Obstacle>(),
                data.CreatedAt
            );

            return puzzle;
        }

        public DataStorage.Firestore.Models.Puzzle Map(Lawnscapers.Models.Puzzle data)
        {
            var puzzle = new DataStorage.Firestore.Models.Puzzle
            {
                Id = data.Id.ToString(),
                Name = data.Name,
                Creator = data.Creator.Name,
                Width = data.Width,
                Height = data.Height,
                PlayerStartPosition = new DataStorage.Firestore.Models.Position { X = data.PlayerStartPosition.X, Y = data.PlayerStartPosition.Y },
                Obstacles = data.Obstacles?.Select(obstacle => new DataStorage.Firestore.Models.Obstacle { Type = obstacle.Type.ToString(), Position = new DataStorage.Firestore.Models.Position { X = obstacle.Position.X, Y = obstacle.Position.Y } }).ToList() ?? new List<DataStorage.Firestore.Models.Obstacle>(),
                CreatedAt = data.CreatedAt,
                PuzzleType = data.PuzzleType.ToString()
            };

            return puzzle;
        }
    }
}