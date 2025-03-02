using Lawnscapers.DataStorage;
using Lawnscapers.Models;
using FirestoreFeedback = Lawnscapers.DataStorage.Firestore.Models.Feedback;

namespace Lawnscapers.Providers
{
    public class FeedbackProvider : IFeedbackProvider
    {
        private readonly IFeedbackRepository _feedbackRepository;
        private readonly IDataMapper<FirestoreFeedback, Feedback> _feedbackMapper;

        public FeedbackProvider(IFeedbackRepository feedbackRepository, IDataMapper<FirestoreFeedback, Feedback> feedbackMapper)
        {
            _feedbackRepository = feedbackRepository;
            _feedbackMapper = feedbackMapper;
        }

        public async Task<Guid> SubmitFeedbackAsync(Feedback feedback)
        {
            var feedbackId = Guid.NewGuid();
            feedback.Id = feedbackId.ToString();

            var firestoreFeedback = _feedbackMapper.Map(feedback);
            await _feedbackRepository.AddAsync(firestoreFeedback);

            return Guid.Parse(feedback.Id);
        }

        public async Task<Feedback> GetFeedbackAsync(string id)
        {
            var firestoreFeedback = await _feedbackRepository.GetByIdAsync(id);

            if (firestoreFeedback == null)
            {
                throw new ArgumentException($"Feedback with id {id} not found.");
            }

            return _feedbackMapper.Map(firestoreFeedback);
        }

        public async Task<IEnumerable<Feedback>> GetAllFeedbackAsync()
        {
            var allFirestoreFeedback = await _feedbackRepository.GetAllAsync();
            var allFeedback = allFirestoreFeedback.Select(x => _feedbackMapper.Map(x));
            return allFeedback;
        }

        public async Task DeleteFeedbackAsync(string id)
        {
            await _feedbackRepository.DeleteAsync(id);
        }
    }
}
