using Lawnscapers.GameLogic.DataStorage;
using Lawnscapers.Models;

namespace Lawnscapers.GameLogic
{
    public class LeaderboardProvider : ILeaderboardProvider
    {
        private readonly IScoreRepository _scoreRepository;

        public LeaderboardProvider(IScoreRepository scoreRepository)
        {
            _scoreRepository = scoreRepository;
        }


    }
}
