using Lawnscapers.DataStorage.Firestore.Models;

namespace Lawnscapers.DataStorage
{
    public class ScoreRepository : IRepository<ScoreEntry>
    {
        private readonly IDatabaseService _databaseService;
        private const string CollectionName = "scores";

        public ScoreRepository(IDatabaseService databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<IEnumerable<ScoreEntry>> GetAllAsync(string? collectionName = null)
        {
            return await _databaseService.GetAllAsync<ScoreEntry>(collectionName ?? CollectionName);
        }

        public async Task<ScoreEntry> GetByIdAsync(Guid id, string? collectionName = null)
        {
            var scores = await _databaseService.GetAllAsync<ScoreEntry>(collectionName ?? CollectionName);
            return scores.First(score => score.PuzzleId == id.ToString());
        }

        public Task AddAsync(ScoreEntry entity, string? collectionName = null)
        {
            return _databaseService.SubmitAsync(collectionName ?? CollectionName, entity.PuzzleId.ToString(), entity);
        }

        public Task UpdateAsync(ScoreEntry entity, string? collectionName = null)
        {
            return _databaseService.SubmitAsync(collectionName ?? CollectionName, entity.PuzzleId.ToString(), entity);
        }

        public Task DeleteAsync(Guid id, string? collectionName = null)
        {
            return _databaseService.DeleteAsync(collectionName ?? CollectionName, id.ToString());
        }
    }
}
