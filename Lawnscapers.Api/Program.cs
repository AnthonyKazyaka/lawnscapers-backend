using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Google.Cloud.Firestore.V1;
using Grpc.Auth;
using Lawnscapers.Extensions;

var builder = WebApplication.CreateBuilder(args);

// Add Firebase configuration
var firebaseProjectId = builder.Configuration["Firebase:ProjectId"];
var credentialsPath = builder.Configuration["Firebase:CredentialsPath"];

if (string.IsNullOrEmpty(firebaseProjectId) || string.IsNullOrEmpty(credentialsPath))
{
    throw new InvalidOperationException("Firebase configuration is missing. Ensure 'Firebase:ProjectId' and 'Firebase:CredentialsPath' are set in appsettings.json or environment variables.");
}

// Initialize FirestoreDb
var credential = GoogleCredential.FromFile(credentialsPath);
var firestoreDb = FirestoreDb.Create(firebaseProjectId, new FirestoreClientBuilder
{
    ChannelCredentials = credential.ToChannelCredentials()
}
.Build());

builder.Services.AddSingleton(firestoreDb);

// Register providers
builder.Services.AddLawnscapersDependencies();

// Add controllers and configure Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
