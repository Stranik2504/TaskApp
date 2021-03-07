using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskApp.Classes
{
    public class Task : INotifyPropertyChanged
    {
        //Выполненость
        private bool isDone;
        //Текст события
        private string text;

        public bool IsDone { get { return isDone; } set { isDone = value; OnPropertyChanged(); } }
        public string Text { get { return text; } set { text = value; OnPropertyChanged(); } }
        //Дата создания события
        public string DateCreate { get; set; } = DateTime.Now.ToShortDateString();

        //Событие вызывающийся, при изменении
        public event PropertyChangedEventHandler PropertyChanged;

        //Метод вызывающийся, для изменения
        private void OnPropertyChanged()
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(text));
        }
    }
}
