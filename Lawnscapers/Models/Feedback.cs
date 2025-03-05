namespace Lawnscapers.Models
{
    public class Feedback
    {
        public string Id { get; set; }
        public string? PlayerId { get; set; }
        public string? Context { get; set; }
        public string? Text { get; set; }
        public DateTime? CreatedAt { get; set; }
    }
}
