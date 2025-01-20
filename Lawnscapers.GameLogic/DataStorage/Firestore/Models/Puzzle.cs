using Google.Cloud.Firestore;

namespace Lawnscapers.DataStorage.Firestore.Models
{
    [FirestoreData]
    public class Puzzle
    {
        [FirestoreProperty("id")]
        public string? Id { get; set; }

        [FirestoreProperty("name")]
        public string? Name { get; set; }

        [FirestoreProperty("creator")]
        public string? Creator { get; set; }

        [FirestoreProperty("width")]
        public int Width { get; set; } = 0;

        [FirestoreProperty("height")]
        public int Height { get; set; } = 0;

        [FirestoreProperty("playerStartPosition")]
        public Position? PlayerStartPosition { get; set; }

        [FirestoreProperty("obstacles")]
        public List<Obstacle> Obstacles { get; set; } = new List<Obstacle>();

        [FirestoreProperty("createdAt")]
        public string? CreatedAt { get; set; }

        [FirestoreProperty("puzzleType")]
        public string? PuzzleType { get; set; }
    }
}