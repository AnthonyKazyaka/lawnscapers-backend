using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lawnscapers.Models
{
    public class Obstacle
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid PuzzleId { get; set; } // Foreign key to Puzzle
        public string Type { get; set; } // E.g., "Wall", "Trap", "Hazard"
        public Position Position { get; set; }
    }

}
