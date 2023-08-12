using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoManager
{
      public class Task
    {
        public int TaskId { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public Boolean IsCompleted { get; set; }

        public Task(int task_id, string title, string description, Boolean isCompleted)
        {
            TaskId = task_id;
            Title = title;
            Description = description;
            IsCompleted = isCompleted;
        }
    }
}
