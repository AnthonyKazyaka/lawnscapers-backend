using Google.Cloud.Firestore;

namespace Lawnscapers.GameLogic.DataStorage
{
    public class FirestoreDatabaseService<T> : IDatabaseService<T>
    {
        private readonly FirestoreDb _db;

        public FirestoreDatabaseService(string projectId)
        {
            _db = FirestoreDb.Create(projectId);
        }

        public async Task<IEnumerable<T>> GetData(string collectionName)
        {
            var querySnapshot = await _db.Collection(collectionName).GetSnapshotAsync();
            return querySnapshot.Documents.Select(doc => doc.ConvertTo<T>());
        }

        public async Task SubmitData(string collectionName, string key, T data)
        {
            var docRef = _db.Collection(collectionName).Document(key);
            await docRef.SetAsync(data);
        }

        public async Task DeleteData(string collectionName, string key)
        {
            var docRef = _db.Collection(collectionName).Document(key);
            await docRef.DeleteAsync();
        }
    }
}
