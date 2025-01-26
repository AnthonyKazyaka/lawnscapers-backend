using Lawnscapers.DataStorage;
using Lawnscapers.DataStorage.Firestore;
using FirestorePlayer = Lawnscapers.DataStorage.Firestore.Models.Player;
using Player = Lawnscapers.Models.Player;

namespace Lawnscapers.Providers
{
    public class PlayerProvider : IPlayerProvider
    {
        private readonly IPlayerRepository _playerRepository;
        private readonly IDataMapper<FirestorePlayer, Player> _playerMapper;

        public PlayerProvider(IPlayerRepository playerRepository, IDataMapper<FirestorePlayer, Player> playerMapper)
        {
            _playerRepository = playerRepository;
            _playerMapper = playerMapper;
        }

        public async Task<Guid> CreatePlayerAsync(Player player)
        {
            player.Id = Guid.NewGuid();
            var firestorePlayer = _playerMapper.Map(player);
            await _playerRepository.AddAsync(firestorePlayer);
            return player.Id;
        }

        public async Task DeletePlayerAsync(Guid playerId)
        {
            await _playerRepository.DeleteAsync(playerId.ToString());
        }

        public async Task<IEnumerable<Player>> GetAllPlayersAsync()
        {
            var dbPlayer = await _playerRepository.GetAllAsync();
            return dbPlayer.Select(player => _playerMapper.Map(player));
        }

        public async Task<Player> GetPlayerAsync(Guid playerId)
        {
            var dbPlayer = await _playerRepository.GetByIdAsync(playerId.ToString());

            if(dbPlayer == null)
            {
                throw new ArgumentException($"Player with id {playerId} not found.");
            }

            return _playerMapper.Map(dbPlayer);
        }

        public async Task<IEnumerable<Player>> GetAllPlayersByIds(IEnumerable<Guid> ids)
        {
            var allPlayers = await _playerRepository.GetAllAsync();
            return allPlayers.Where(player => ids.Contains(Guid.Parse(player.Id))).Select(player => _playerMapper.Map(player));
        }

        public async Task<Player> GetPlayerAsync(string username)
        {
            var allPlayers = await _playerRepository.GetAllAsync();
            var player = allPlayers.FirstOrDefault(p => p.Name == username);

            if (player == null)
            {
                throw new ArgumentException($"Player with username {username} not found.");
            }

            return _playerMapper.Map(player);
        }

        public async Task UpdatePlayerAsync(Player player)
        {
            var dbPlayer = _playerMapper.Map(player);
            await _playerRepository.UpdateAsync(player.Id.ToString(), dbPlayer);
        }
    }
}
