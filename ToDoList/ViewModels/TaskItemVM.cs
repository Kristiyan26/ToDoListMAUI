using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.DataAccess;
using ToDoList.Models;

namespace ToDoList.ViewModels
{

    public partial class TaskItemVM : ObservableObject
    {
        //private readonly TaskListDbContext _context;

        private readonly TaskRepository _repository;

        public ObservableCollection<TaskItem> Tasks { get; set; } = new();

        [ObservableProperty]
        private TaskItem _selectedTask;

        public TaskItemVM()
        {
            _repository = new TaskRepository();
            LoadTasks();

        }

        private void LoadTasks()
        {
            Tasks.Clear();
            foreach (var task in _repository.GetAllTasks())
            {
                Tasks.Add(task);
            }
            //foreach (TaskItem task in _context.Tasks)
            //    Tasks.Add(task);

        }

        [RelayCommand]
        public void AddTask(TaskItem newTask)
        {
            _repository.AddTask(newTask);
            Tasks.Add(newTask);


            //_context.Tasks.Add(newTask);
            //_context.SaveChanges();
          
        }

        [RelayCommand]
        public void UpdateTask(TaskItem updatedTask)
        {
            _repository.UpdateTask(updatedTask);

            
            //  var existingTask = Tasks.FirstOrDefault(t=>t.Id==updatedTask.Id);
            ////if (existingTask != null)
            ////{
            ////    int index = Tasks.IndexOf(existingTask);
            ////    Tasks[index] = updatedTask;
            ////}
     
                //_context.Tasks.Update(updatedTask);
                //_context.SaveChanges();
             
            }

        [RelayCommand]
        public void DeleteTask(TaskItem task)
        {
            _repository.DeleteTask(task.Id);
            Tasks.Remove(task);

            //_context.Tasks.Remove(task);
            //_context.SaveChanges();

        }
    }

}
