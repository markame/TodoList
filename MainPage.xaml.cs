using System.Collections.ObjectModel;
using System.Formats.Tar;
using System.Text.Json;
using TodoList;

namespace TodoList
{
    public partial class MainPage : ContentPage
    {
        public ObservableCollection<TaskItem> TaskList { get; set; } = new ObservableCollection<TaskItem>();

        public MainPage()
        {
            InitializeComponent();
            LoadTasks(); // Carregar tarefas ao inicializar a página
            tasksListView.ItemsSource = TaskList;
        }

        // Método para adicionar nova tarefa
        private void OnAddTaskClicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(taskEntry.Text))
            {
                TaskList.Add(new TaskItem { TaskName = taskEntry.Text, Category = categoryPicker.SelectedItem.ToString(),DueDate = dueDatePicker.Date});
                taskEntry.Text = string.Empty;
                categoryPicker.SelectedItem = string.Empty;
               
                SaveTasks();
            }
        }

        // Método para marcar tarefa como concluída
        private void OnCompleteTaskClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var task = button.BindingContext as TaskItem;

            if (task != null)
            {
                task.TaskName += " (Concluída)";
                DisplayAlert("Tarefa finalizada", "A tarefa"+ task.TaskName,"Ok" );
            }
        }

        // Método para remover tarefa
        private void OnDeleteTaskClicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            button.TextColor=Colors.White;
            var task = button.BindingContext as TaskItem;

            if (task != null)
            {
                TaskList.Remove(task);
            }
        }
        private void SaveTasks()
        {
            var tasksJson = JsonSerializer.Serialize(TaskList);
            Preferences.Set("tasks", tasksJson);
        }
        private void DeleteTasks()
        {

        }

        // Método para carregar as tarefas do armazenamento local
        private void LoadTasks()
        {
            var tasksJson = Preferences.Get("tasks", string.Empty);
            if (!string.IsNullOrEmpty(tasksJson))
            {
                TaskList = JsonSerializer.Deserialize<ObservableCollection<TaskItem>>(tasksJson);
                tasksListView.ItemsSource = TaskList;
            }
        }
    }
}


