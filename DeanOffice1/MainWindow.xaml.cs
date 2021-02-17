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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DeanOffice1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DatabaseEntities db = new DatabaseEntities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void FacultiesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = FacultiesList.SelectedIndex;
            if (index != -1)
            {
                var groups = (FacultiesList.Items[index] as Faculties).Groups;
                GroupsList.ItemsSource = groups;
            }
        }

        private void LoadFaculties()
        {
            FacultiesList.ItemsSource = db.Faculties.ToList();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            LoadFaculties();
        }
        private void GroupsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int index = GroupsList.SelectedIndex;
            if(index != -1)
            {
                var students = (GroupsList.Items[index] as Groups).Students;
                StudentsList.ItemsSource = students;
            }
        }

        private void StudentsList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Students student = StudentsList.SelectedItem as Students;
            Panel3.DataContext = student;
        }

        private void FacultyCreate_Click(object sender, RoutedEventArgs e)
        {
            FacultiesEditor facultiesEditor = new FacultiesEditor();
            facultiesEditor.Action.Content = "Добавить";
            if (facultiesEditor.ShowDialog() == true)
            {
                db.Faculties.Add(new Faculties() { Name = facultiesEditor.Name.Text});
                db.SaveChanges();
                LoadFaculties();
                MessageBox.Show("Факультет успешно добавлен!", "Сообщение",
                    MessageBoxButton.OK, MessageBoxImage.Information);

            }
        }

        private void FacultyUpdate_Click(object sender, RoutedEventArgs e)
        {
            FacultiesEditor facultiesEditor = new FacultiesEditor();
            FacultiesEditor changeEditor = new FacultiesEditor();
            facultiesEditor.Action.Content = "Найти";
            if (facultiesEditor.ShowDialog() == true)
            {
                int index = 0;
                var faculties = db.Faculties.ToList();
                foreach (var faculty in faculties)
                {
                    index++;
                    if (faculty.Name == facultiesEditor.Name.Text)
                    {
                        MessageBox.Show("Факультет найден!");
                        changeEditor.Action.Content = "Сохранить изменения";
                        if(changeEditor.ShowDialog() == true)
                        {
                            faculty.Name = changeEditor.Name.Text;
                            db.SaveChanges();
                            LoadFaculties();
                            MessageBox.Show("Факультет успешно изменен!", "Сообщение",
                                MessageBoxButton.OK, MessageBoxImage.Information);
                            break;
                        }
                    }
                }
            }
        }

        private void FacultyDelete_Click(object sender, RoutedEventArgs e)
        {
            FacultiesEditor facultiesEditor = new FacultiesEditor();
            facultiesEditor.Action.Content = "Удалить";
            if (facultiesEditor.ShowDialog() == true)
            {
                var faculties = db.Faculties.ToList();
                bool success = false;
                foreach(var faculty in faculties)
                {
                    if(faculty.Name == facultiesEditor.Name.Text)
                    {
                        db.Faculties.Remove(faculty);
                        db.SaveChanges();
                        LoadFaculties();
                        success = true;
                        MessageBox.Show("Факультет успешно удален!", "Сообщение",
                            MessageBoxButton.OK, MessageBoxImage.Information);
                        break;
                    }
                }
                if (!success)
                {
                    MessageBox.Show("Факультет не найден!", "Сообщение",
                        MessageBoxButton.OK, MessageBoxImage.Warning);
                }

            }
        }

        private void StudentCreate_Click(object sender, RoutedEventArgs e)
        {
            StudentEditor se = new StudentEditor();
            se.SaveButton.Content = "Добавить студента";
            se.FacultiesList.ItemsSource = db.Faculties.ToList();
           // se.SubjectsList.ItemsSource = db.Subjects.ToList();
            if(se.ShowDialog() == true)
            {
                foreach (var group in db.Groups)
                {
                    if(group.Name == se.groupName)
                        se.student.GroupId = group.Id;
                }
                db.Students.Add(se.student);
                db.SaveChanges();
                LoadFaculties();
            }
        }
    }
}
