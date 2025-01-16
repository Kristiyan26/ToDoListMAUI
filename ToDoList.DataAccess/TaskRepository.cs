using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.DataAccess
{
    public class TaskRepository
    {
        private readonly List<TaskItem> _tasks;

        public TaskRepository()
        {
            _tasks = new List<TaskItem>
            {
                new TaskItem { Id = 1, Title = "Buy groceries", Description = "Milk, Bread, Cheese", IsCompleted = false },
                new TaskItem { Id = 2, Title = "Workout", Description = "Run 5km",IsCompleted = false },
                new TaskItem { Id = 3, Title = "Call John", Description = "Discuss the project updates", IsCompleted = true }
            };
        }
        public List<TaskItem> GetAllTasks()
        {
            return _tasks;
        }

        // Add a new task
        public void AddTask(TaskItem task)
        {
            task.Id = _tasks.Count+1;
            _tasks.Add(task);
        }

        // Update an existing task
        public void UpdateTask(TaskItem task)
        {
            var existingTask = _tasks.FirstOrDefault(t => t.Id == task.Id);
            if (existingTask != null)
            {
                existingTask.Title = task.Title;
                existingTask.Description = task.Description;
                existingTask.IsCompleted = task.IsCompleted;
            }
        }

        // Delete a task
        public void DeleteTask(int id)
        {
            var task = _tasks.FirstOrDefault(t => t.Id == id);
            if (task != null)
            {
                _tasks.Remove(task);
            }
        }
    }
}
