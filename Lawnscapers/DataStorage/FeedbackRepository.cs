using Lawnscapers.DataStorage.Firestore.Models;

namespace Lawnscapers.DataStorage
{
    public class FeedbackRepository : IFeedbackRepository
    {
        public Task AddAsync(Feedback entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(string id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Feedback>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task<Feedback?> GetByIdAsync(string id, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(string id, Feedback entity, CancellationToken cancellationToken = default)
        {
            throw new NotImplementedException();
        }
    }
}
