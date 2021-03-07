using System;
using System.Collections.Generic;
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
    public partial class ListTask : Window
    {
        //Конструктор ListTask
        public ListTask()
        {
            try
            {
                InitializeComponent();

                LoadTasks();
            }
            catch (Exception ex) { $"[ListTask]: error to initialize ListTask({ex.Message})".Log(); }
        }

        //Отчистка текста, при помощьи выподающего списка
        private void MenuItem_Click_Clear(object sender, RoutedEventArgs e)
        {
            try { Tasks.Text = ""; } catch (Exception ex) { $"[ListTask]: error to clear Tasks({ex.Message})".Log(); }
        }

        //Добавление текста из буфер обмена в TextBox, при помощьи выподающего списка
        private void MenuItem_Click_Add(object sender, RoutedEventArgs e)
        {
            try { Tasks.Text = Clipboard.GetText(); } catch (Exception ex) { $"[ListTask]: error to copy text in Tasks form Clipborad({ex.Message})".Log(); }
        }

        //Добавление текста из TextBox в буфер обмена, при помощьи выподающего списка
        private void MenuItem_Click_Copy(object sender, RoutedEventArgs e)
        {
            try { Clipboard.SetText(Tasks.Text); } catch (Exception ex) { $"[ListTask]: error to copy text from Tasks in Clipborad({ex.Message})".Log(); }
        }

        //Загрузка директорий
        public void LoadTasks()
        {
            try
            {
                //Добавление фильтра
                string name = "Grid_Task_";

                //Отчиска предыдущих
                Tasking.Children.Clear();

                foreach (var names in Classes.Tasker.Lists.Keys)
                {
                    //Создание контейнера компонентов
                    Grid grid = new Grid();
                    grid.Name = name + names;
                    //Classes.Tasker.Lists

                    //Создание и копирование свойст(текст)
                    Button childButton = Grid_Task_0.Children[0] as Button;

                    Button button = new Button() { AllowDrop = childButton.AllowDrop, Visibility = childButton.Visibility, CacheMode = childButton.CacheMode, Clip = childButton.Clip, ClipToBounds = childButton.ClipToBounds, Effect = childButton.Effect, Focusable = childButton.Focusable, IsEnabled = childButton.IsEnabled, IsHitTestVisible = childButton.IsHitTestVisible, IsManipulationEnabled = childButton.IsManipulationEnabled, Opacity = childButton.Opacity, OpacityMask = childButton.OpacityMask, RenderSize = childButton.RenderSize, RenderTransform = childButton.RenderTransform, RenderTransformOrigin = childButton.RenderTransformOrigin, SnapsToDevicePixels = childButton.SnapsToDevicePixels, Uid = childButton.Uid, BindingGroup = childButton.BindingGroup, ContextMenu = childButton.ContextMenu, Cursor = childButton.Cursor, DataContext = childButton.DataContext, FlowDirection = childButton.FlowDirection, FocusVisualStyle = childButton.FocusVisualStyle, ForceCursor = childButton.ForceCursor, Height = childButton.Height, HorizontalAlignment = childButton.HorizontalAlignment, InputScope = childButton.InputScope, Language = childButton.Language, LayoutTransform = childButton.LayoutTransform, Margin = childButton.Margin, MaxHeight = childButton.MaxHeight, MaxWidth = childButton.MaxWidth, MinHeight = childButton.MinHeight, MinWidth = childButton.MinWidth, OverridesDefaultStyle = childButton.OverridesDefaultStyle, Resources = childButton.Resources, Style = childButton.Style, Tag = childButton.Tag, ToolTip = childButton.ToolTip, UseLayoutRounding = childButton.UseLayoutRounding, VerticalAlignment = childButton.VerticalAlignment, Width = childButton.Width, Content = names, FontFamily = childButton.FontFamily, FontSize = childButton.FontSize, FontStretch = childButton.FontStretch, FontStyle = childButton.FontStyle, FontWeight = childButton.FontWeight, Foreground = childButton.Foreground, Padding = childButton.Padding, BorderBrush = childButton.BorderBrush, BorderThickness = childButton.BorderThickness, ClickMode = childButton.ClickMode, Command = childButton.Command, CommandParameter = childButton.CommandParameter, CommandTarget = childButton.CommandTarget, ContentStringFormat = childButton.ContentStringFormat, ContentTemplate = childButton.ContentTemplate, ContentTemplateSelector = childButton.ContentTemplateSelector, HorizontalContentAlignment = childButton.HorizontalContentAlignment, IsCancel = childButton.IsCancel, IsDefault = childButton.IsDefault, IsTabStop = childButton.IsTabStop, TabIndex = childButton.TabIndex, Template = childButton.Template, VerticalContentAlignment = childButton.VerticalContentAlignment, Name = "Button_Task_" + names };

                    foreach (Trigger item in childButton.Triggers)
                    {
                        button.Triggers.Add(item);
                    }

                    foreach (InputBinding item in childButton.InputBindings)
                    {
                        button.InputBindings.Add(item);
                    }

                    foreach (CommandBinding item in childButton.CommandBindings)
                    {
                        button.CommandBindings.Add(item);
                    }

                    button.Click += Open_Task_MouseDown;

                    //Добавление элемента в контейнер
                    grid.Children.Add(button);

                    //Создание и копирование свойст(Удаление)
                    Ellipse childElip = Ellipse_Task_0;

                    Ellipse ellipse = new Ellipse() { AllowDrop = childElip.AllowDrop, Visibility = childElip.Visibility, CacheMode = childElip.CacheMode, Clip = childElip.Clip, ClipToBounds = childElip.ClipToBounds, Effect = childElip.Effect, Focusable = childElip.Focusable, IsEnabled = childElip.IsEnabled, IsHitTestVisible = childElip.IsHitTestVisible, IsManipulationEnabled = childElip.IsManipulationEnabled, Opacity = childElip.Opacity, OpacityMask = childElip.OpacityMask, RenderSize = childElip.RenderSize, RenderTransform = childElip.RenderTransform, RenderTransformOrigin = childElip.RenderTransformOrigin, SnapsToDevicePixels = childElip.SnapsToDevicePixels, Uid = childElip.Uid, BindingGroup = childElip.BindingGroup, ContextMenu = childElip.ContextMenu, Cursor = childElip.Cursor, DataContext = childElip.DataContext, FlowDirection = childElip.FlowDirection, FocusVisualStyle = childElip.FocusVisualStyle, ForceCursor = childElip.ForceCursor, Height = childElip.Height, HorizontalAlignment = childElip.HorizontalAlignment, InputScope = childElip.InputScope, Language = childElip.Language, LayoutTransform = childElip.LayoutTransform, Margin = childElip.Margin, MaxHeight = childElip.MaxHeight, MaxWidth = childElip.MaxWidth, MinHeight = childElip.MinHeight, MinWidth = childElip.MinWidth, Name = "Ellipse_Task_" + names, OverridesDefaultStyle = childElip.OverridesDefaultStyle, Resources = childElip.Resources, Stretch = childElip.Stretch, Stroke = childElip.Stroke, StrokeDashArray = childElip.StrokeDashArray, StrokeDashCap = childElip.StrokeDashCap, StrokeDashOffset = childElip.StrokeDashOffset, StrokeEndLineCap = childElip.StrokeEndLineCap, StrokeLineJoin = childElip.StrokeLineJoin, StrokeMiterLimit = childElip.StrokeMiterLimit, StrokeStartLineCap = childElip.StrokeStartLineCap, StrokeThickness = childElip.StrokeThickness, Style = childElip.Style, Tag = childElip.Tag, ToolTip = childElip.ToolTip, UseLayoutRounding = childElip.UseLayoutRounding, VerticalAlignment = childElip.VerticalAlignment, Width = childElip.Width };

                    foreach (Trigger item in childElip.Triggers)
                    {
                        ellipse.Triggers.Add(item);
                    }

                    foreach (InputBinding item in childElip.InputBindings)
                    {
                        ellipse.InputBindings.Add(item);
                    }

                    foreach (CommandBinding item in childElip.CommandBindings)
                    {
                        ellipse.CommandBindings.Add(item);
                    }

                    ellipse.MouseDown += Delete_Task_MouseDown;

                    //Добавление элемента в контейнер
                    grid.Children.Add(ellipse);

                    grid.Margin = Grid_Task_0.Margin;

                    grid.Visibility = Visibility.Visible;

                    //Добавление контйнера фильтра 
                    Tasking.Children.Add(grid);
                }
            }
            catch (Exception ex) { $"[ListTask]: error to laod tasks({ex.Message})".Log(); }
        }

        //Добавление директории
        private void Tasks_KeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    Classes.Tasker.Lists.Add(Tasks.Text, new System.ComponentModel.BindingList<Classes.Task>());
                    Tasks.Text = "";
                    Classes.Tasker.SaveTasks();
                    LoadTasks();
                }
            }
            catch (Exception ex) { $"[ListTask]: error to add tasks({ex.Message})".Log(); }
        }

        //Удаление диоектории
        private void Delete_Task_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (Classes.Tasker.Lists.Count > 0)
                {
                    if (MessageBox.Show("Вы точно хотите удалить этот раздел? \r\n Если вы хотите его удалить удалятся все задачи в нем", "Удаление", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        string name = (sender as Ellipse).Name.ToString().Split('_')[2];
                        Classes.Tasker.Lists.Remove(name);
                        Classes.Tasker.SaveTasks();
                        LoadTasks();
                    }
                }
            }
            catch (Exception ex) { $"[ListTask]: error to delete direcory({ex.Message})".Log(); }
        }

        //Переход на просмотр задач в данной дериктории
        private void Open_Task_MouseDown(object sender, RoutedEventArgs e)
        {
            try
            {
                string name = (sender as Button).Name.ToString().Split('_')[2];

                Classes.Tasker.SelectDirect(name);

                new Tasks().Show();
                Close();
            }
            catch (Exception ex) { $"[ListTask]: error to tab in Tasks({ex.Message})".Log(); }
        }
    }
}
