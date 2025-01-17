using ToDoList.DataAccess;
using ToDoList.Models;
using ToDoList.ViewModels;

namespace ToDoList.Views;

public partial class AddTaskPage : ContentPage
{

    public TaskItem NewTask { get; set; }
    private readonly TaskItemVM _taskItemVM;

    public AddTaskPage(TaskItemVM itemVM)
    {
        NewTask = new TaskItem();
        _taskItemVM = itemVM;

        InitializeComponent();
        BindingContext = this;
    }

    private async void OnAddClicked(object sender, EventArgs e)
    {

        _taskItemVM.AddTask(NewTask);
        await Navigation.PopAsync();

    }
    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }

} 