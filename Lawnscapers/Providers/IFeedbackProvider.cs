using Lawnscapers.Models;

namespace Lawnscapers.Providers
{
    public interface IFeedbackProvider
    {
        Task<Guid> SubmitFeedbackAsync(Feedback feedback);
        Task<Feedback> GetFeedbackAsync(string id);
        Task<IEnumerable<Feedback>> GetAllFeedbackAsync();
        Task DeleteFeedbackAsync(string id);
    }
}
