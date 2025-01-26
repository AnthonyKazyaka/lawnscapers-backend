
namespace Lawnscapers.DataStorage.Firestore
{
    public class PlayerMapper : IDataMapper<DataStorage.Firestore.Models.Player, Lawnscapers.Models.Player>
    {
        private readonly IDataMapper<Models.Score, Lawnscapers.Models.Score> _scoreMapper;

        public PlayerMapper(IDataMapper<DataStorage.Firestore.Models.Score, Lawnscapers.Models.Score> scoreMapper)
        {
            _scoreMapper = scoreMapper;
        }

        public Lawnscapers.Models.Player Map(DataStorage.Firestore.Models.Player data)
        {
            var player = new Lawnscapers.Models.Player
            {
                Id = Guid.Parse(data.Id),
                Name = data.Name,
                CreatedAt = data.CreatedAt
            };

            return player;
        }

        public DataStorage.Firestore.Models.Player Map(Lawnscapers.Models.Player data)
        {
            var player = new DataStorage.Firestore.Models.Player
            {
                Id = data.Id.ToString(),
                Name = data.Name,
                CreatedAt = data.CreatedAt
            };

            return player;
        }
    }
}