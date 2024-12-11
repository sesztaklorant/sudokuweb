using System;
using System.Collections.Generic;

namespace sudokuweb.SudokuModels;

public partial class Solution
{
    public int SolutionId { get; set; }

    public int? PuzzleId { get; set; }

    public int? UserId { get; set; }

    public string SolvedGrid { get; set; } = null!;

    public DateTime? DateSolved { get; set; }

    public int? TimeTaken { get; set; }

    public virtual Puzzle? Puzzle { get; set; }

    public virtual User? User { get; set; }
}
