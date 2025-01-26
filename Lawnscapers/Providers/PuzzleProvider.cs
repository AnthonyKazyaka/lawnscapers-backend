using Lawnscapers.DataStorage;
using Lawnscapers.DataStorage.Firestore;
using Lawnscapers.Enums;
using FirestorePuzzle = Lawnscapers.DataStorage.Firestore.Models.Puzzle;
using Puzzle = Lawnscapers.Models.Puzzle;

namespace Lawnscapers.Providers
{
    public class PuzzleProvider : IPuzzleProvider
    {
        private readonly IPuzzleRepository _puzzleRepository;
        private readonly IDataMapper<FirestorePuzzle, Puzzle> _puzzleMapper;

        public PuzzleProvider(IPuzzleRepository puzzleRepository, IDataMapper<FirestorePuzzle, Puzzle> puzzleMapper)
        {
            _puzzleRepository = puzzleRepository;
            _puzzleMapper = puzzleMapper;
        }

        public async Task AddPuzzleAsync(Puzzle puzzle)
        {
            var firestorePuzzle = _puzzleMapper.Map(puzzle);
            await _puzzleRepository.AddAsync(firestorePuzzle);
        }

        public async Task DeletePuzzleAsync(Guid puzzleId)
        {
            await _puzzleRepository.DeleteAsync(puzzleId.ToString());
        }

        public async Task<IDictionary<PuzzleType, IEnumerable<Puzzle>>> GetAllPuzzlesAsync()
        {
            var allPuzzles = new Dictionary<PuzzleType, IEnumerable<Puzzle>>();

            foreach (var puzzleType in Enum.GetValues<PuzzleType>())
            {
                var puzzles = await GetPuzzlesByTypeAsync(puzzleType);
                allPuzzles.Add(puzzleType, puzzles);
            }

            return allPuzzles;
        }

        public async Task<Puzzle> GetPuzzleAsync(Guid puzzleId)
        {
            var firestorePuzzle = await _puzzleRepository.GetByIdAsync(puzzleId.ToString());

            if (firestorePuzzle == null)
            {
                throw new ArgumentException($"Puzzle with id {puzzleId} not found.");
            }

            return _puzzleMapper.Map(firestorePuzzle);
        }

        public async Task<IEnumerable<Puzzle>> GetPuzzlesByTypeAsync(PuzzleType puzzleType)
        {
            var allPuzzles = await _puzzleRepository.GetAllAsync();
            return allPuzzles
                .Where(p => p.PuzzleType == puzzleType.ToString())
                .Select(_puzzleMapper.Map);
        }

        public async Task UpdatePuzzleAsync(Puzzle puzzle)
        {
            if(puzzle.Id == null)
            {
                throw new ArgumentNullException("Puzzle must have an id to be updated.");
            }

            var firestorePuzzle = _puzzleMapper.Map(puzzle);
            await _puzzleRepository.UpdateAsync(firestorePuzzle.Id!, firestorePuzzle);
        }
    }
}
