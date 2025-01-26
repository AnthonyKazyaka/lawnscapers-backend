using Lawnscapers.Models;

namespace Lawnscapers.Providers
{
    public interface IPlayerProvider
    {
        Task<Player> GetPlayerAsync(Guid playerId);
        Task<Player> GetPlayerAsync(string username);
        Task<IEnumerable<Player>> GetAllPlayersAsync();
        Task<IEnumerable<Player>> GetAllPlayersByIds(IEnumerable<Guid> ids);
        Task<Guid> CreatePlayerAsync(Player player);
        Task UpdatePlayerAsync(Player player);
        Task DeletePlayerAsync(Guid playerId);
    }
}
