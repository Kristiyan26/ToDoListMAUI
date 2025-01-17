using ToDoList.DataAccess;
using ToDoList.Models;
using ToDoList.ViewModels;

namespace ToDoList.Views;

public partial class EditTaskPage : ContentPage
{
    public TaskItem Task { get; set; }
    public TaskItemVM _itemVM { get; set; }

    public EditTaskPage(TaskItem task, TaskItemVM itemVM)
    {
        Task = task;
        _itemVM = itemVM;

        InitializeComponent();

        BindingContext = task;
    }

    private async void OnSaveClicked(object sender, EventArgs e)
    {
        _itemVM.UpdateTask(Task);
        await Navigation.PopAsync();
    }
    private async void OnCancelClicked(object sender, EventArgs e)
    {
        await Navigation.PopAsync();
    }
}