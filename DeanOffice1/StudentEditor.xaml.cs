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

namespace DeanOffice1
{
    /// <summary>
    /// Логика взаимодействия для StudentEditor.xaml
    /// </summary>
    public partial class StudentEditor : Window
    {
        public Students student = new Students();
        public string groupName { get; set; }
        public StudentEditor()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(StudentName.Text))
                    throw new Exception("Вы не ввели ФИО!");
                else if (StudentBirth.SelectedDate > DateTime.Now)
                    throw new Exception("Дата рождения не может быть больше текущей даты!");
                else if (String.IsNullOrWhiteSpace(StudentPhone.Text))
                    throw new Exception("Вы не ввели номер телефона!");
                else if (String.IsNullOrWhiteSpace(StudentEmail.Text))
                    throw new Exception("Вы не ввели email!");
                else if (String.IsNullOrWhiteSpace(StudentPhone.Text))
                    throw new Exception("Вы не ввели номер телефона!");
                else
                {
                    student.Name = StudentName.Text;
                    string date = StudentBirth.SelectedDate.Value.ToShortDateString();
                    student.Birth = Convert.ToDateTime(date);
                    student.Phone = StudentPhone.Text;
                    student.Email = StudentEmail.Text;
                    //
                    groupName = GroupsList.Text;
                    this.DialogResult = true;
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message, "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
        private void FacultiesList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            foreach(var faculty in FacultiesList.Items)
            {
                if((faculty as Faculties).Name == (FacultiesList.SelectedItem as Faculties).Name)
                {
                    GroupsList.Items.Clear();
                    foreach (var group in (faculty as Faculties).Groups)
                        GroupsList.Items.Add(new Groups() { Name = group.Name });
                    //
                    if (GroupsList.Items.Count > 0)
                        GroupsList.SelectedIndex = 0;
                    break;
                    
                }
            }
        }
    }
}
