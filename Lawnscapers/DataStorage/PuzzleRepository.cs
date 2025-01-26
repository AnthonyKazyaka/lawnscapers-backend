using Google.Cloud.Firestore;
using Lawnscapers.DataStorage.Firestore.Models;

namespace Lawnscapers.DataStorage.Firestore
{
    public class PuzzleRepository : IPuzzleRepository
    {
        private readonly FirestoreDb _db;
        private const string CollectionName = "puzzles";

        public PuzzleRepository(FirestoreDb db) => _db = db;

        public async Task<IEnumerable<Puzzle>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var snapshot = await _db.Collection(CollectionName).GetSnapshotAsync(cancellationToken);
            return snapshot.Documents.Select(doc => doc.ConvertTo<Puzzle>());
        }

        public async Task<Puzzle?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var doc = await _db.Collection(CollectionName).Document(id).GetSnapshotAsync(cancellationToken);
            return doc.Exists ? doc.ConvertTo<Puzzle>() : null;
        }

        public async Task AddAsync(Puzzle entity, CancellationToken cancellationToken = default)
        {
            await _db.Collection(CollectionName).AddAsync(entity, cancellationToken);
        }

        public async Task UpdateAsync(string id, Puzzle entity, CancellationToken cancellationToken = default)
        {
            var doc = _db.Collection(CollectionName).Document(id);
            await doc.SetAsync(entity, SetOptions.MergeAll, cancellationToken);
        }

        public async Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            var doc = _db.Collection(CollectionName).Document(id);
            await doc.DeleteAsync(null, cancellationToken);
        }

        public Task<IEnumerable<Puzzle>> GetPuzzlesByDifficultyAsync(string difficulty, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
