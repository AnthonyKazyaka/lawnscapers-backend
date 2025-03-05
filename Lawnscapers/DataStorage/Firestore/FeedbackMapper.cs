namespace Lawnscapers.DataStorage.Firestore
{
    public class FeedbackMapper : IDataMapper<DataStorage.Firestore.Models.Feedback, Lawnscapers.Models.Feedback>
    {
        public Lawnscapers.Models.Feedback Map(Models.Feedback data)
        {
            return new Lawnscapers.Models.Feedback
            {
                Id = data.Id,
                PlayerId = data.PlayerId,
                Context = data.Context,
                Text = data.Text,
                CreatedAt = data.CreatedAt
            };
        }

        public Models.Feedback Map(Lawnscapers.Models.Feedback data)
        {
            return new Models.Feedback
            {
                Id = data.Id,
                PlayerId = data.PlayerId,
                Context = data.Context,
                Text = data.Text,
                CreatedAt = data.CreatedAt
            };
        }
    }
}
