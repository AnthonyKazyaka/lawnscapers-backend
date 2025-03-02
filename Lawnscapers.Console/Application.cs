using Lawnscapers.DataStorage;
using Lawnscapers.Models;
using Lawnscapers.Providers;
using DbPuzzle = Lawnscapers.DataStorage.Firestore.Models.Puzzle;
using DbScore = Lawnscapers.DataStorage.Firestore.Models.Score;

namespace Lawnscapers.Console
{
    public class Application
    {
        private readonly IPlayerProvider _playerProvider;
        private readonly IPuzzleProvider _puzzleProvider;
        private readonly IScoreProvider _scoreProvider;
        private readonly IFeedbackProvider _feedbackProvider;

        public Application(IPlayerProvider playerProvider, IPuzzleProvider puzzleProvider, IScoreProvider scoreProvider, IFeedbackProvider feedbackProvider)
        {
            _playerProvider = playerProvider;
            _puzzleProvider = puzzleProvider;
            _scoreProvider = scoreProvider;
            _feedbackProvider = feedbackProvider;
        }

        public async Task RunAsync()
        {
            var currentPath = Environment.CurrentDirectory;
            var fileName = "updated-schema_lawnscapers-database-export.json";
            var filePath = System.IO.Path.Combine(currentPath, fileName);

            System.Console.WriteLine($"Reading Firestore data from {filePath}");
            var data = System.IO.File.ReadAllText(filePath);
            var deserializedData = System.Text.Json.JsonSerializer.Deserialize<ProcessedData>(data);

            if(deserializedData == null)
            {
                System.Console.WriteLine("Unable to process the data in the file.");
                return;
            }

            // Loop through the deserialized data and insert it into the database
            //foreach (var player in deserializedData.Players)
            //{
            //    System.Console.WriteLine($"Inserting player {player.Id}");
            //    await _playerProvider.CreatePlayerAsync(player);
            //}

            //foreach (var puzzle in deserializedData.Puzzles)
            //{
            //    System.Console.WriteLine($"Inserting puzzle {puzzle.Id}");

            //    // Convert the DbPuzzle to a Puzzle
            //    if(puzzle.Creator == null)
            //    {
            //        System.Console.WriteLine($"Skipping puzzle {puzzle.Id} because it has no creator.");
            //        continue;
            //    }

            //    var creator = deserializedData.Players.FirstOrDefault(p => p.Id == puzzle.Creator);
            //    if (creator == null)
            //    {
            //        System.Console.WriteLine($"Skipping puzzle {puzzle.Id} because the creator {puzzle.Creator} was not found.");
            //        continue;
            //    }

            //    DateTimeOffset createdAt = new DateTimeOffset(puzzle.CreatedAt);
            //    var createdAtUtc = createdAt.UtcDateTime;

            //    var puzzleCreator = new Player { Id = puzzle.Creator, Name = creator.Name, CreatedAt = creator.CreatedAt };
            //    var convertedPuzzle = new Puzzle(creator.Id, puzzle.Name!, puzzleCreator, puzzle.Width, puzzle.Height, new Position(puzzle.PlayerStartPosition!.X, puzzle.PlayerStartPosition.Y), puzzle.Obstacles.Select(x => new Obstacle(Enums.ObstacleType.Wall, new Position(x.Position!.X, x.Position.Y))).ToList(), createdAtUtc);
            //    await _puzzleProvider.AddPuzzleAsync(convertedPuzzle);
            //}

            //foreach (var score in deserializedData.Scores)
            //{
            //    System.Console.WriteLine($"Inserting score {score.Id}");

            //    var player = deserializedData.Players.FirstOrDefault(p => p.Id == score.PlayerId);
            //    var convertedScore = new Score(score.Id, score.PuzzleId, player, score.Moves, score.ScoreHash, score.Timestamp);

            //    await _scoreProvider.SubmitScoreAsync(convertedScore);
            //}

            //foreach (var feedback in deserializedData.Feedback)
            //{
            //    System.Console.WriteLine($"Inserting feedback {feedback.Id}");
            //    await _feedbackProvider.SubmitFeedbackAsync(feedback);
            //}
        }
    }

    public class ProcessedData
    {
        public List<Player> Players { get; set; } = new List<Player>();
        public List<DbPuzzle> Puzzles { get; set; } = new List<DbPuzzle>();
        public List<DbScore> Scores { get; set; } = new List<DbScore>();
        public List<Feedback> Feedback { get; set; } = new List<Feedback>();
    }
}