using Google.Cloud.Firestore;
using Lawnscapers.DataStorage.Firestore.Models;

namespace Lawnscapers.DataStorage.Firestore
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly FirestoreDb _db;
        private const string CollectionName = "scores";

        public ScoreRepository(FirestoreDb db) => _db = db;

        public async Task<IEnumerable<Score>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var snapshot = await _db.Collection(CollectionName).GetSnapshotAsync(cancellationToken);
            return snapshot.Documents.Select(doc => doc.ConvertTo<Score>());
        }

        public async Task<Score?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var doc = await _db.Collection(CollectionName).Document(id).GetSnapshotAsync(cancellationToken);
            return doc.Exists ? doc.ConvertTo<Score>() : null;
        }

        public async Task AddAsync(Score entity, CancellationToken cancellationToken = default)
        {
            await _db.Collection(CollectionName).AddAsync(entity, cancellationToken);
        }

        public async Task UpdateAsync(string id, Score entity, CancellationToken cancellationToken = default)
        {
            var doc = _db.Collection(CollectionName).Document(id);
            await doc.SetAsync(entity, SetOptions.MergeAll, cancellationToken);
        }

        public async Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            var doc = _db.Collection(CollectionName).Document(id);
            await doc.DeleteAsync(null, cancellationToken);
        }

        public async Task<IEnumerable<Score>> GetScoresByPuzzleIdAsync(string puzzleId, CancellationToken cancellationToken = default)
        {
            var query = _db.Collection(CollectionName).WhereEqualTo("puzzleId", puzzleId);
            var snapshot = await query.GetSnapshotAsync(cancellationToken);
            return snapshot.Documents.Select(doc => doc.ConvertTo<Score>());
        }

        public async Task<IEnumerable<Score>> GetScoresByPlayerIdAsync(string playerId, CancellationToken cancellationToken = default)
        {
            var query = _db.Collection(CollectionName).WhereEqualTo("playerId", playerId);
            var snapshot = await query.GetSnapshotAsync(cancellationToken);
            return snapshot.Documents.Select(doc => doc.ConvertTo<Score>());
        }
    }
}
