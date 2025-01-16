
using ToDoList.DataAccess;
using ToDoList.Models;
using ToDoList.ViewModels;

namespace ToDoList.Views;

public partial class TaskListPage : ContentPage
{
    private readonly TaskItemVM _taskItemVM;
    public TaskListPage()
	{

        _taskItemVM = new TaskItemVM();

        BindingContext = _taskItemVM;

        InitializeComponent();

    }

 
    private void OnTaskDoubleTapped(object sender, ItemTappedEventArgs e)
    {
        if (e.Item is TaskItem task)
        {
            if (task.IsCompleted)
            {
                task.IsCompleted = false;
            }
            else
            {
                task.IsCompleted = true;
            }
        }
    }

    private async void OnEditTaskClicked(object sender, EventArgs e)
    {
        var task = (TaskItem)((Button)sender).CommandParameter;

        var editPage = new EditTaskPage(task, _taskItemVM);
        await Navigation.PushAsync(editPage);
    }

    private async void AddTask_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new AddTaskPage(_taskItemVM));
    }

    private void OnDeleteTaskClicked(object sender, EventArgs e)
    {
        TaskItem task = (TaskItem)((Button)sender).CommandParameter;

        _taskItemVM.DeleteTask(task);   
    }
}