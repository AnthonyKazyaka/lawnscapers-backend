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

            serviceCollection.AddScoped<IPuzzleRepository, PuzzleRepository>();
            serviceCollection.AddScoped<IScoreRepository, ScoreRepository>();
            serviceCollection.AddScoped<IPlayerRepository, PlayerRepository>();
            serviceCollection.AddScoped<IFeedbackRepository, FeedbackRepository>();

            return serviceCollection;
        }

        public static IServiceCollection AddMapperDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IDataMapper<DataStorage.Firestore.Models.Score, Models.Score>, ScoreMapper>();
            serviceCollection.AddScoped<IDataMapper<DataStorage.Firestore.Models.Puzzle, Models.Puzzle>, PuzzleMapper>();
            serviceCollection.AddScoped<IDataMapper<DataStorage.Firestore.Models.Player, Models.Player>, PlayerMapper>();
            serviceCollection.AddScoped<IDataMapper<DataStorage.Firestore.Models.Feedback, Models.Feedback>, FeedbackMapper>();

            return serviceCollection;
        }

        public static IServiceCollection AddProviderDependencies(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<IPuzzleProvider, PuzzleProvider>();
            serviceCollection.AddScoped<IScoreProvider, ScoreProvider>();
            serviceCollection.AddScoped<IPlayerProvider, PlayerProvider>();
            serviceCollection.AddScoped<IFeedbackProvider, FeedbackProvider>();

            return serviceCollection;
        }
    }
}
