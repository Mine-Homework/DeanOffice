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
    /// Логика взаимодействия для FacultiesEditor.xaml
    /// </summary>
    public partial class FacultiesEditor : Window
    {
        public string FName;
        public FacultiesEditor()
        {
            InitializeComponent();
        }


        private void Action_Click(object sender, RoutedEventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(Name.Text))
            {
                FName = Name.Text;
                this.DialogResult = true;
            }
            else
                MessageBox.Show("Вы не ввели название факультета!", "Предупреждение",
                    MessageBoxButton.OK, MessageBoxImage.Warning);
        }
    }
}
