using Google.Cloud.Firestore;

namespace Lawnscapers.DataStorage.Firestore.Models
{
    [FirestoreData]
    public class Position
    {
        [FirestoreProperty("x")]
        public int X { get; set; }
        [FirestoreProperty("y")]
        public int Y { get; set; }
    }
}
