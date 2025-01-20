using Lawnscapers.DataStorage.Firestore.Models;

namespace Lawnscapers.DataStorage
{
    public class PuzzleRepository : IRepository<Puzzle>
    {
        private const string AllPuzzlesCollectionKey = "puzzles";
        private readonly IDatabaseService _db;

        public PuzzleRepository(IDatabaseService db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Puzzle>> GetAllAsync(string? collectionName = null)
        {
            collectionName ??= AllPuzzlesCollectionKey;
            return await _db.GetAllAsync<Puzzle>(collectionName);
        }

        public async Task<Puzzle> GetByIdAsync(Guid id, string? collectionName = null)
        {
            collectionName ??= AllPuzzlesCollectionKey;
            return await _db.GetAsync<Puzzle>(collectionName, id.ToString());
        }

        public async Task AddAsync(Puzzle entity, string? collectionName = null)
        {
            collectionName ??= AllPuzzlesCollectionKey;
            //await _db.SubmitAsync(collectionName, entity.Id.ToString(), entity);
        }

        public async Task UpdateAsync(Puzzle entity, string? collectionName = null)
        {
            collectionName ??= AllPuzzlesCollectionKey;
            //await _db.SubmitAsync(collectionName, entity.Id.ToString(), entity);
        }

        public async Task DeleteAsync(Guid id, string? collectionName = null)
        {
            collectionName ??= AllPuzzlesCollectionKey;
            await _db.DeleteAsync(collectionName, id.ToString());
        }
    }
}
