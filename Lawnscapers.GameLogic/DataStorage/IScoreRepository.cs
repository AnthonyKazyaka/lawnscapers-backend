using Lawnscapers.GameLogic.DataStorage.Models;

namespace Lawnscapers.GameLogic.DataStorage
{
    public interface IScoreRepository
    {
        Task<IDictionary<string, IEnumerable<ScoreEntry>>> Get();
        Task<IEnumerable<ScoreEntry>> Get(string puzzleId);
        Task Submit(ScoreEntry scoreEntry);
    }
}
