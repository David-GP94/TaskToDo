using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskService.Domain.Entities
{
    public class ProjectTask
    {
        public int Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }
        public bool IsCompleted { get; private set; }
        public DateTime CreatedDate { get; private set; }

        public ProjectTask() { }  //Para EF Core

        public ProjectTask(string title, string description)
        {
            if (string.IsNullOrWhiteSpace(title))
                throw new ArgumentException("title cannot be empty.", nameof(title));

            Title = title;
            Description = description ?? string.Empty;
            IsCompleted = false;
            CreatedDate = DateTime.Now;
        }
        public void Complete()
        {
            IsCompleted = true;
        }
    }
}
