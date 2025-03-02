using Google.Cloud.Firestore;
using Lawnscapers.DataStorage.Firestore.Models;

namespace Lawnscapers.DataStorage
{
    public class FeedbackRepository : IFeedbackRepository
    {
        private readonly FirestoreDb _db;
        private const string CollectionName = "feedback";

        public FeedbackRepository(FirestoreDb db)
        {
            _db = db;
        }

        public async Task AddAsync(Feedback entity, CancellationToken cancellationToken = default)
        {
            _ = await _db.Collection(CollectionName).AddAsync(entity, cancellationToken);
        }

        public async Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            _ = await _db.Collection(CollectionName).Document(id).DeleteAsync(null, cancellationToken);
        }

        public async Task<IEnumerable<Feedback>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            var snapshot = await _db.Collection(CollectionName).GetSnapshotAsync(cancellationToken);
            return snapshot.Documents.Select(doc => doc.ConvertTo<Feedback>());
        }

        public async Task<Feedback?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            var doc = await _db.Collection(CollectionName).Document(id).GetSnapshotAsync(cancellationToken);
            return doc.Exists ? doc.ConvertTo<Feedback>() : null;
        }

        public Task UpdateAsync(string id, Feedback entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
