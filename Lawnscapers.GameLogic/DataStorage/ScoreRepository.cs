using Lawnscapers.GameLogic.DataStorage.Models;

namespace Lawnscapers.GameLogic.DataStorage
{
    public class ScoreRepository : IScoreRepository
    {
        private readonly IDatabaseService<ScoreEntry> _databaseService;
        private const string CollectionName = "scores";

        public ScoreRepository(IDatabaseService<ScoreEntry> databaseService)
        {
            _databaseService = databaseService;
        }

        public async Task<IEnumerable<ScoreEntry>> GetAllAsync()
        {
            return await _databaseService.GetData(CollectionName);
        }

        public async Task<ScoreEntry?> GetByIdAsync(Guid id)
        {
            var scores = await _databaseService.GetData(CollectionName);
            return scores.FirstOrDefault(score => score.PuzzleId == id);
        }

        public Task AddAsync(ScoreEntry entity)
        {
            return _databaseService.SubmitData(CollectionName, entity.PuzzleId.ToString(), entity);
        }

        public Task UpdateAsync(ScoreEntry entity)
        {
            return _databaseService.SubmitData(CollectionName, entity.PuzzleId.ToString(), entity);
        }

        public Task DeleteAsync(Guid id)
        {
            return _databaseService.DeleteData(CollectionName, id.ToString());
        }
    }
}
