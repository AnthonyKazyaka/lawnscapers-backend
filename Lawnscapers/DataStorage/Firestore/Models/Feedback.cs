using Google.Cloud.Firestore;

namespace Lawnscapers.DataStorage.Firestore.Models
{
    [FirestoreData]
    public class Feedback
    {
        [FirestoreDocumentId]
        public string Id { get; set; } = string.Empty;
        [FirestoreProperty("playerId")]
        public string? PlayerId { get; set; }
        [FirestoreProperty("context")]
        public string? Context { get; set; }
        [FirestoreProperty("text")]
        public string? Text { get; set; }
        [FirestoreProperty("createdAt")]
        public DateTime? CreatedAt { get; set; }
    }
}
