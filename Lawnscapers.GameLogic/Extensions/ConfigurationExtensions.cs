using Lawnscapers.GameLogic.DataStorage;
using Microsoft.Extensions.DependencyInjection;

namespace Lawnscapers.GameLogic.Extensions
{
    public static class ConfigurationExtensions
    {


        public static IServiceCollection AddDatabaseDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<ILeaderboardProvider, LeaderboardProvider>();
            serviceCollection.AddSingleton<IPuzzleRepository, PuzzleRepository>();
            serviceCollection.AddSingleton<IScoreRepository, ScoreRepository>();

            return serviceCollection;
        }
    }
}
