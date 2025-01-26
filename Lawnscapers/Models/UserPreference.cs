namespace Lawnscapers.Models
{
    public class UserPreference
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PlayerId { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public UserPreference(Guid id, Guid playerId, string key, string value)
        {
            Id = id;
            PlayerId = playerId;
            Key = key;
            Value = value;
        }
    }

}
