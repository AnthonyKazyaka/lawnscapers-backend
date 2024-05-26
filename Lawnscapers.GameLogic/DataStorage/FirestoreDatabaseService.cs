using Google.Cloud.Firestore;

namespace Lawnscapers.GameLogic.DataStorage
{
    public class FirestoreDatabaseService<T> : IDatabaseService<T>
    {
        protected readonly FirestoreDb _db;
        protected string _collectionName = "";

        public FirestoreDatabaseService()
        {
            // Initialize _db. You'd typically have your Firestore settings/connection logic here.
            _db = FirestoreDb.Create("your-project-id");
        }

        public async Task<IEnumerable<T>> GetData(string collectionName)
        {
            return await GetDataFromCollection(collectionName);
        }

        protected virtual async Task<IEnumerable<T>> GetDataFromCollection(string collectionName)
        {
            var querySnapshot = await _db.Collection(collectionName).GetSnapshotAsync();
            List<T> items = new ();
            foreach (var document in querySnapshot.Documents)
            {
                items.Add(document.ConvertTo<T>());
            }
            return items;
        }

        public async Task SubmitData(string key, T data)
        {
            DocumentReference docRef = _db.Collection(_collectionName).Document(key);
            await docRef.SetAsync(data);
        }
    }
}