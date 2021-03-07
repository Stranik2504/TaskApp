using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace TaskApp.Windows
{
    public partial class Tasks : Window
    {
        //Конструктор Tasks
        public Tasks()
        {
            try
            {
                InitializeComponent();

                Start();
            }
            catch (Exception ex) { $"[Tasks]: error to initialize Tasks({ex.Message})".Log(); }
        }

        //Зугрузка всех задач в данной дериктории
        private void Start()
        {
            try
            {
                foreach (var names in Classes.Tasker.Lists.Keys)
                {
                    MenuItem item = new MenuItem();
                    item.Header = names;
                    item.BorderThickness = new Thickness(0);
                    item.Background = (Brush)new BrushConverter().ConvertFromString("#F9ECFE");
                    item.FontFamily = new FontFamily("Arial");
                    item.FontSize = 16;
                    item.Height = 30;
                    item.Click += (object senders, RoutedEventArgs es) => { TaskList.ItemsSource = Classes.Tasker.Lists[names]; };
                    Menu.Items.Add(item);
                }

                if (Classes.Tasker.NameDirect != null && Classes.Tasker.NameDirect != "" && Classes.Tasker.NameDirect != " ")
                {
                    TaskList.ItemsSource = Classes.Tasker.listDirect;

                    Classes.Tasker.listDirect.ListChanged += TaskDataList_ListChanged;
                }
            }
            catch (Exception ex) { $"[Tasks]: error to start({ex.Message})".Log(); }
        }

        //Сохранение данных, при изменении состояния 
        private void TaskDataList_ListChanged(object sender, ListChangedEventArgs e)
        {
            try
            {
                if (e.ListChangedType == ListChangedType.ItemAdded || e.ListChangedType == ListChangedType.ItemDeleted || e.ListChangedType == ListChangedType.ItemChanged)
                {
                    Classes.Tasker.SaveTasks();
                }
            }
            catch (Exception ex) { $"[Tasks]: error to save change({ex.Message})".Log(); }
        }

        //Сохранение и отвязка события обнавление, при закрытии окна
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            try
            {
                if (Classes.Tasker.listDirect != null) { Classes.Tasker.listDirect.ListChanged -= TaskDataList_ListChanged; }
                Classes.Tasker.SaveTasks();
            }
            catch (Exception ex) { $"[Tasks]: error to closing window({ex.Message})".Log(); }
        }

        //Кнопка перемещения на выбор директории
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (MessageBox.Show("Вы точно хотите вернуться на главный экран?", "Выход", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    new ListTask().Show();
                    Classes.Tasker.ClearSelectDirect();
                    Close();
                }
            }
            catch (Exception ex) { $"[Tasks]: error to close and tab to ListTask({ex.Message})".Log(); }
        }

        //Удаление события с помощью меню
        private void MenuItem_Click_Delete(object sender, RoutedEventArgs e)
        {
            try
            {
                Classes.Tasker.listDirect.Remove(TaskList.SelectedItem as Classes.Task);

                Classes.Tasker.SaveTasks();
            }
            catch (Exception ex) { $"[Tasks]: error to delete event({ex.Message})".Log(); }
        }
    }
}
