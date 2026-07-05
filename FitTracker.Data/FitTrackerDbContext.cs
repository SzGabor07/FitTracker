using System;
using System.Collections.Generic;
using System.Text;
using FitTracker.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace FitTracker.Data
{
    public class FitTrackerDbContext : DbContext
    {
        public FitTrackerDbContext(DbContextOptions<FitTrackerDbContext> options) : base(options)
        {
        }
        public DbSet<DailyLog> DailyLogs { get; set; }
        public DbSet<ExerciseSession> ExerciseSessions { get; set; }
        public DbSet<MealLog> MealLogs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DailyLog>()
                .HasMany(d => d.Exercises)
                .WithOne(e => e.DailyLog)
                .HasForeignKey(e => e.DailyLogId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<DailyLog>()
                .HasMany(d => d.Meals)
                .WithOne(m => m.DailyLog)
                .HasForeignKey(m => m.DailyLogId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
