using Lawnscapers.DataStorage;
using Player = Lawnscapers.Models.Player;
using FirestorePlayer = Lawnscapers.DataStorage.Firestore.Models.Player;

namespace Lawnscapers.Providers
{
    public class PlayerProvider : IPlayerProvider
    {
        private readonly IRepository<FirestorePlayer> _playerRepository;

        public PlayerProvider(IRepository<FirestorePlayer> playerRepository)
        {
            _playerRepository = playerRepository;
        }

        public async Task AddPlayerAsync(Player player)
        {
            var firestorePlayer = Map(player);
            await _playerRepository.AddAsync(firestorePlayer);
        }

        public async Task DeletePlayerAsync(Guid playerId)
        {
            await _playerRepository.DeleteAsync(playerId);
        }

        public async Task<IEnumerable<Player>> GetAllPlayersAsync()
        {
            var dbPlayer = await _playerRepository.GetAllAsync();
            return dbPlayer.Select(player => Map(player));
        }

        public async Task<Player> GetPlayerAsync(Guid playerId)
        {
            var dbPlayer = await _playerRepository.GetByIdAsync(playerId);
            return Map(dbPlayer);
        }

        public async Task<IEnumerable<Player>> GetAllPlayersByIds(IEnumerable<Guid> ids)
        {
            var allPlayers = await _playerRepository.GetAllAsync();
            return allPlayers.Where(player => ids.Contains(Guid.Parse(player.Id))).Select(player => Map(player));
        }

        public async Task<Player> GetPlayerAsync(string username)
        {
            var allPlayers = await _playerRepository.GetAllAsync();
            var player = allPlayers.FirstOrDefault(p => p.Name == username);
            return Map(player);
        }

        public async Task UpdatePlayerAsync(Player player)
        {
            var dbPlayer = Map(player);
            await _playerRepository.UpdateAsync(dbPlayer);
        }

        private static Player Map(FirestorePlayer player)
        {
            return new Player
            {
                Id = Guid.Parse(player.Id),
                Name = player.Name,
                CreatedAt = player.CreatedAt
            };
        }

        private static FirestorePlayer Map(Player player)
        {
            return new FirestorePlayer
            {
                Id = player.Id.ToString(),
                Name = player.Name,
                CreatedAt = player.CreatedAt
            };
        }
    }
}
