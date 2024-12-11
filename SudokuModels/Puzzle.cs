using System;
using System.Collections.Generic;

namespace sudokuweb.SudokuModels;

public partial class Puzzle
{
    public int PuzzleId { get; set; }

    public string Name { get; set; } = null!;

    public string Grid { get; set; } = null!;

    public string? DifficultyLevel { get; set; }

    public DateTime? DateCreated { get; set; }

    public virtual ICollection<Solution> Solutions { get; set; } = new List<Solution>();
}
