using Google.Cloud.Firestore;

namespace Lawnscapers.DataStorage.Firestore.Models
{
    [FirestoreData]
    public class Player
    {
        [FirestoreDocumentId]
        public string Id { get; set; } = string.Empty;

        [FirestoreProperty("name")]
        public string Name { get; set; } = string.Empty;

        [FirestoreProperty("createdAt")]
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
