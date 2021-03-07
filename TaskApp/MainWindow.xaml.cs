using System;
using System.Collections.Generic;
using System.ComponentModel; //BindingList
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TaskApp
{
    public partial class MainWindow : Window
    {
        //Конструктор MainWindow
        public MainWindow()
        {
            try
            {
                if (System.IO.File.Exists("Error.log")) { if (System.IO.File.OpenText("Error.log").ReadToEnd().Count() >= 100000) { using (var writer = new System.IO.StreamWriter("Error.log")) { writer.Write(""); } } }

                Classes.Tasker.LoadTasks();
                new Windows.ListTask().Show();
                Close();
            }
            catch (Exception ex) { $"[MainWindow] error to start project({ex.Message})".Log(); }
        }
    }

    //Класс для дополнения
    public static class Addition
    {
        public static void Log(this string log)
        {
            try { System.IO.File.AppendAllText(@"Error.log", "[" + DateTime.Now.ToString() + "]" + log + " \n"); } catch { }
        }
    }
}
