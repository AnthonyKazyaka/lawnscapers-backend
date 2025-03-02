using Google.Cloud.Firestore;

namespace Lawnscapers.DataStorage.Firestore
{
    public class FirestoreDatabaseService : IDatabaseService
    {
        protected readonly FirestoreDb _database;
        private const string DefaultCollection = "default";

        public FirestoreDatabaseService(FirestoreDb db)
        {
            _database = db;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>(string collectionName, CancellationToken cancellationToken = default)
        {
            collectionName ??= DefaultCollection;
            var querySnapshot = await _database.Collection(collectionName).GetSnapshotAsync(cancellationToken);
            return querySnapshot.Documents.Select(doc => doc.ConvertTo<T>());
        }

        public async Task<T> GetAsync<T>(string collectionName, string key, CancellationToken cancellationToken = default)
        {
            var docRef = _database.Collection(collectionName).Document(key);
            var snapshot = await docRef.GetSnapshotAsync(cancellationToken);
            return snapshot.Exists ? snapshot.ConvertTo<T>() : default!;
        }

        public Task SubmitAsync<T>(string collectionName, string key, T data, CancellationToken cancellationToken = default)
        {
            var docRef = _database.Collection(collectionName).Document(key);
            return docRef.SetAsync(data, cancellationToken: cancellationToken);
        }

        public Task DeleteAsync(string collectionName, string key, CancellationToken cancellationToken = default)
        {
            var docRef = _database.Collection(collectionName).Document(key);
            return docRef.DeleteAsync(cancellationToken: cancellationToken);
        }
    }
}
