
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Models;

namespace ToDoList.DataAccess
{
    public class TaskListDbContext(DbContextOptions<TaskListDbContext> options) : DbContext(options)
    {
     
            public DbSet<TaskItem> Tasks { get; set; }

          
            protected override void OnModelCreating(ModelBuilder modelBuilder)
            {
                modelBuilder.Entity<TaskItem>().HasData(
                    new TaskItem { Id = 1, Title = "Read", Description = "Read 20 pages of a book today", IsCompleted = false },
                    new TaskItem { Id = 2, Title = "Drink Some Water", Description = "Atleast 5 litres a day", IsCompleted = false },
                    new TaskItem { Id = 3, Title = "Trash", Description = "Throw the trash out", IsCompleted = false }
                );
            }
        
    }
}
