using Lawnscapers.Models;

namespace Lawnscapers.Providers
{
    public interface IPlayerProvider
    {
        Task<Player> GetPlayerAsync(string playerId);
        Task<Player> GetPlayerByUsernameAsync(string username);
        Task<IEnumerable<Player>> GetAllPlayersAsync();
        Task<IEnumerable<Player>> GetAllPlayersByIds(IEnumerable<string> ids);
        Task<string> CreatePlayerAsync(Player player);
        Task UpdatePlayerAsync(Player player);
        Task DeletePlayerAsync(string playerId);
    }
}
