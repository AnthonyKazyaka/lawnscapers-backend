using Lawnscapers.DataStorage.Firestore.Models;

namespace Lawnscapers.DataStorage
{
    public class PlayerRepository : IRepository<Player>
    {
        private const string CollectionName = "players";
        private readonly IDatabaseService _db;

        public PlayerRepository(IDatabaseService db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Player>> GetAllAsync(string? collectionName = null)
        {
            collectionName ??= CollectionName;
            return await _db.GetAllAsync<Player>(collectionName);
        }

        public async Task<Player> GetByIdAsync(Guid id, string? collectionName = null)
        {
            collectionName ??= CollectionName;
            return await _db.GetAsync<Player>(collectionName, id.ToString());
        }

        public async Task AddAsync(Player entity, string? collectionName = null)
        {
            collectionName ??= CollectionName;
            //await _db.SubmitAsync(collectionName, entity.Id.ToString(), entity);
        }

        public async Task UpdateAsync(Player entity, string? collectionName = null)
        {
            collectionName ??= CollectionName;
            //await _db.SubmitAsync(collectionName, entity.Id.ToString(), entity);
        }

        public async Task DeleteAsync(Guid id, string? collectionName = null)
        {
            collectionName ??= CollectionName;
            await _db.DeleteAsync(collectionName, id.ToString());
        }
    }
}
