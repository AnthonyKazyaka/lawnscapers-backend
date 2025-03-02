using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Grpc.Auth;
using Lawnscapers.Console;
using Lawnscapers.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = Host.CreateDefaultBuilder(args)
    .ConfigureAppConfiguration((context, config) =>
    {
        config.AddUserSecrets<Program>();
    })
    .ConfigureServices((context, services) =>
    {
        var configuration = context.Configuration;

        // Retrieve Firebase configuration
        var firebaseProjectId = configuration["Firebase:ProjectId"];
        var credentialsPath = configuration["Firebase:CredentialsPath"];

        if (string.IsNullOrEmpty(firebaseProjectId) || string.IsNullOrEmpty(credentialsPath))
        {
            var vars = Environment.GetEnvironmentVariables();
            throw new InvalidOperationException("Firebase configuration is missing. Ensure 'Firebase:ProjectId' and 'Firebase:CredentialsPath' are set in appsettings.json or environment variables.");
        }

        // Initialize FirestoreDb
        var credential = GoogleCredential.FromFile(credentialsPath);
        var firestoreDb = FirestoreDb.Create(firebaseProjectId, new FirestoreClientBuilder
        {
            ChannelCredentials = credential.ToChannelCredentials()
        }
        .Build());

        services.AddSingleton(firestoreDb);

        // Register Lawnscapers dependencies
        services.AddLawnscapersDependencies();

        services.AddSingleton<Application>();
    })
    .Build();

// Resolve services and run the application logic
using var scope = host.Services.CreateScope();
var services = scope.ServiceProvider;
var application = services.GetRequiredService<Application>();

try
{
    Console.WriteLine("Lawnscapers Console Application Initialized Successfully.");

    await application.RunAsync();
}
catch (Exception ex)
{
    Console.WriteLine($"An error occurred: {ex.Message}");
}
