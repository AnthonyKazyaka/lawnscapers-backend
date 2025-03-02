using Google.Cloud.Firestore;

namespace Lawnscapers.DataStorage.Firestore.Models
{
    [FirestoreData]
    public class UserPreference
    {
        [FirestoreDocumentId]
        public string Id { get; set; } = string.Empty;

        [FirestoreProperty("playerId")]
        public string PlayerId { get; set; } = string.Empty;

        [FirestoreProperty("key")]
        public string Key { get; set; } = string.Empty;

        [FirestoreProperty("value")]
        public string Value { get; set; } = string.Empty;
    }
}
