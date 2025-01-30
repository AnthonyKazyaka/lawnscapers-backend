using Google.Cloud.Firestore;
using Lawnscapers.Providers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawnscapers.Console
{
    public class Application
    {
        private readonly IPlayerProvider _playerProvider;

        public Application(IPlayerProvider playerProvider)
        {
            _playerProvider = playerProvider;
        }

        public async Task RunAsync()
        {
            var allPlayers = await _playerProvider.GetAllPlayersAsync();

            foreach (var player in allPlayers)
            {
                System.Console.WriteLine($"Player ID: {player.Id}");
                System.Console.WriteLine(); // Adjust according to your data structure
            }
        }
    }

}
