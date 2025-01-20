using Lawnscapers.DataStorage;
using Lawnscapers.DataStorage.Firestore;
using Lawnscapers.Providers;
using Microsoft.Extensions.DependencyInjection;

namespace Lawnscapers.Extensions
{
    public static class ConfigurationExtensions
    {

        public static IServiceCollection AddLawnscapersDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddRepositoryDependencies();
            serviceCollection.AddProviderDependencies();
            serviceCollection.AddMapperDependencies();

            return serviceCollection;
        }

        public static IServiceCollection AddRepositoryDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IDatabaseService, FirestoreDatabaseService>();

            serviceCollection.AddScoped<IRepository<DataStorage.Firestore.Models.Puzzle>, PuzzleRepository>();
            serviceCollection.AddScoped<IRepository<DataStorage.Firestore.Models.ScoreEntry>, ScoreRepository>();
            serviceCollection.AddScoped<IRepository<DataStorage.Firestore.Models.Player>, PlayerRepository>();


            return serviceCollection;
        }

        public static IServiceCollection AddMapperDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IDataMapper<DataStorage.Firestore.Models.ScoreEntry, Models.ScoreEntry>, ScoreEntryMapper>();
            serviceCollection.AddScoped<IDataMapper<DataStorage.Firestore.Models.Puzzle, Models.Puzzle>, PuzzleMapper>();
            serviceCollection.AddScoped<IDataMapper<DataStorage.Firestore.Models.Player, Models.Player>, PlayerMapper>();

            return serviceCollection;
        }

        public static IServiceCollection AddProviderDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IPuzzleProvider, PuzzleProvider>();
            serviceCollection.AddScoped<ILeaderboardProvider, LeaderboardProvider>();
            serviceCollection.AddScoped<IPlayerProvider, PlayerProvider>();

            return serviceCollection;
        }
    }
}
