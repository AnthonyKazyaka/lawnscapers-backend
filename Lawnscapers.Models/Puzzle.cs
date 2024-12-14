﻿using System.ComponentModel.DataAnnotations;

namespace Lawnscapers.Models
{
    public class Puzzle
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public Player Creator { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Position PlayerStartPosition { get; set; }
        public List<Obstacle> Obstacles { get; set; } = new List<Obstacle>();
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public bool IsPublic { get; set; } = false;


        public Puzzle(Guid id, string name, Player creator, int width, int height, Position playerStartPosition, List<Obstacle> obstacles, DateTime createdAt)
        {
            // Validate name is not null or empty
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Name cannot be null or empty");
            }

            Id = id;
            Name = name;
            Creator = creator;
            Width = width;
            Height = height;
            PlayerStartPosition = playerStartPosition;
            Obstacles = obstacles;
            CreatedAt = createdAt;
        }
    }
}