using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskService.Domain.Entities;

namespace TaskService.Infrastructure.Persistence
{
    public class TaskDbContext : DbContext
    {
        public DbSet<ProjectTask> Tasks { get; set; }

        public TaskDbContext(DbContextOptions<TaskDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectTask>(entity =>
            {
                entity.HasKey(t => t.Id);
                entity.Property(t => t.Title).IsRequired().HasMaxLength(100);
                entity.Property(t => t.Description).HasMaxLength(500);
            });
        }
    }
}
