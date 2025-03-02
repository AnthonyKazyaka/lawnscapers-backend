using Google.Cloud.Firestore;
using Lawnscapers.DataStorage.Firestore.Models;

namespace Lawnscapers.DataStorage.Firestore
{
    public class PlayerRepository : IPlayerRepository
    {
        private readonly FirestoreDb _db;
        private const string CollectionName = "players";

        public PlayerRepository(FirestoreDb db) => _db = db;

        public async Task<IEnumerable<Player>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var snapshot = await _db.Collection(CollectionName).GetSnapshotAsync(cancellationToken);
            return snapshot.Documents.Select(doc => doc.ConvertTo<Player>());
        }

        public async Task<Player?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var doc = await _db.Collection(CollectionName).Document(id).GetSnapshotAsync(cancellationToken);
            return doc.Exists ? doc.ConvertTo<Player>() : null;
        }

        public async Task AddAsync(Player entity, CancellationToken cancellationToken = default)
        {
            _ = await _db.Collection(CollectionName).AddAsync(entity, cancellationToken);
        }

        public async Task UpdateAsync(string id, Player entity, CancellationToken cancellationToken = default)
        {
            var doc = _db.Collection(CollectionName).Document(id);
            _ = await doc.SetAsync(entity, SetOptions.MergeAll, cancellationToken);
        }

        public async Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            var doc = _db.Collection(CollectionName).Document(id);
            _ = await doc.DeleteAsync(null, cancellationToken);
        }
    }
}
