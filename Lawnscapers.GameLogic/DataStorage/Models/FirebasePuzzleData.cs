using Google.Cloud.Firestore;
using Lawnscapers.Models;

namespace Lawnscapers.GameLogic.DataStorage.Models
{
    [FirestoreData]
    public class FirebasePuzzleData
    {
        [FirestoreProperty] public Guid Id { get; set; }
        [FirestoreProperty] public string Name { get; set; }
        [FirestoreProperty] public string Creator { get; set; }
        [FirestoreProperty] public int Width { get; set; }
        [FirestoreProperty] public int Height { get; set; }
        [FirestoreProperty] public Position PlayerStartPosition { get; set; }
        [FirestoreProperty] public List<Position> Obstacles { get; set; }
        [FirestoreProperty] public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public FirebasePuzzleData(Guid id, string name, string creator, int width, int height, Position playerStartPosition, List<Position> obstaclePositions, DateTime createdAt)
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