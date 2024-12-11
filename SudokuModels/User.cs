using System;
using System.Collections.Generic;

namespace sudokuweb.SudokuModels;

public partial class User
{
    public int UserId { get; set; }

    public string UserName { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Email { get; set; }

    public DateTime? DateOfBirth { get; set; }

    public virtual ICollection<Solution> Solutions { get; set; } = new List<Solution>();
}
