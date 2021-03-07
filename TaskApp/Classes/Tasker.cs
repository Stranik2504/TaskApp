using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.ComponentModel;
using Newtonsoft.Json;

namespace TaskApp.Classes
{
    static class Tasker
    {
        //Путь файла
        private static string path = "taskDataList.json";
        //Все события
        private static Dictionary<string, BindingList<Task>> lists = new Dictionary<string, BindingList<Task>>();

        public static Dictionary<string, BindingList<Task>> Lists { get { return lists; } set { lists = value; } }

        //Название выбранной директории
        public static string NameDirect;
        //События в выбранной директории
        public static BindingList<Task> listDirect;

        //Загрузка событий
        public static void LoadTasks()
        {
            try
            {
                if (File.Exists(path))
                {
                    using (var reader = File.OpenText(path))
                    {
                        lists = JsonConvert.DeserializeObject<Dictionary<string, BindingList<Task>>>(reader.ReadToEnd());
                    }
                }
                else { lists = new Dictionary<string, BindingList<Task>>(); }

                CheakDate();
            }
            catch (Exception ex) { $"[Tasker]: error to laod tasks({ex.Message})".Log(); }
        }

        //Сохранения событий
        public static void SaveTasks()
        {
            try
            {
                using (var writer = new StreamWriter(path))
                {
                    writer.Write(JsonConvert.SerializeObject(lists));
                }
            }
            catch (Exception ex) { $"[Tasker]: error to save tasks({ex.Message})".Log(); }
        }

        //Выбор директории
        public static void SelectDirect(string NameSelectedDirect)
        {
            try
            {
                NameDirect = NameSelectedDirect;
                listDirect = lists[NameSelectedDirect];
            }
            catch (Exception ex) { $"[Tasker]: error to select directory({ex.Message})".Log(); }
        }

        //Сброс выбранной директории
        public static void ClearSelectDirect()
        {
            try
            {
                NameDirect = "";
                listDirect = null;
            }
            catch (Exception ex) { $"[Tasker]: error to clear select directory({ex.Message})".Log(); }
        }

        //Проверка на действительность сделанных событий(Исчезают через 30 дней)
        private static void CheakDate()
        {
            try
            {
                for (int i = 0; i < lists.Values.Count; i++)
                {
                    for (int j = 0; j < lists.Values.ToList()[i].Count; j++)
                    {
                        if (lists.Values.ToList()[i][j].IsDone == true)
                        {
                            //new TimeSpan(30, 0, 0, 0) - 30 - количество дней, после которых событие удаляется
                            if (Convert.ToDateTime(Convert.ToDateTime(lists.Values.ToList()[i][j].DateCreate).Add(new TimeSpan(30, 0, 0, 0)).ToShortDateString()) <= Convert.ToDateTime(DateTime.Now.ToShortDateString()))
                            {
                                lists.Values.ToList()[i].RemoveAt(j);
                                j--;
                            }
                        }
                    }

                    if (lists.Values.ToList()[i].Count == 0) { lists.Remove(lists.Keys.ToList()[i]); }
                }
            }
            catch (Exception ex) { $"[Tasker]: error or cheak date({ex.Message})".Log(); }
        }
    }
}
