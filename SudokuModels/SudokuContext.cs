using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace sudokuweb.SudokuModels;

public partial class SudokuContext : DbContext
{
    public SudokuContext()
    {
    }

    public SudokuContext(DbContextOptions<SudokuContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Puzzle> Puzzles { get; set; }

    public virtual DbSet<Solution> Solutions { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=sudokukiszolgalo.database.windows.net;Initial Catalog=sudoku;Persist Security Info=True;User ID=sesztaklorant;Password=RealMadrid2002;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Puzzle>(entity =>
        {
            entity.HasKey(e => e.PuzzleId).HasName("PK__Puzzles__19F7B8026B70B20F");

            entity.Property(e => e.DateCreated).HasColumnType("date");
            entity.Property(e => e.DifficultyLevel).HasMaxLength(50);
            entity.Property(e => e.Grid).HasMaxLength(81);
            entity.Property(e => e.Name).HasMaxLength(100);
        });

        modelBuilder.Entity<Solution>(entity =>
        {
            entity.HasKey(e => e.SolutionId).HasName("PK__Solution__6B633AD0A8BF1AAB");

            entity.Property(e => e.DateSolved).HasColumnType("date");
            entity.Property(e => e.SolvedGrid).HasMaxLength(81);

            entity.HasOne(d => d.Puzzle).WithMany(p => p.Solutions)
                .HasForeignKey(d => d.PuzzleId)
                .HasConstraintName("FK__Solutions__Puzzl__60A75C0F");

            entity.HasOne(d => d.User).WithMany(p => p.Solutions)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Solutions__UserI__619B8048");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CC4CAC0CF308");

            entity.Property(e => e.DateOfBirth).HasColumnType("date");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(128);
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
