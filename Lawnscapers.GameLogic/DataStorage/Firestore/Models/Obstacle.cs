using Google.Cloud.Firestore;

namespace Lawnscapers.DataStorage.Firestore.Models
{
    [FirestoreData]
    public class Obstacle
    {
        [FirestoreProperty("type")]
        public string? Type { get; set; }

        [FirestoreProperty("position")]
        public Position? Position { get; set; }
    }
}
