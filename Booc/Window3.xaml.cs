using Booc.Models;
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

namespace Booc
{
    /// <summary>
    /// Логика взаимодействия для Window3.xaml
    /// </summary>
    public partial class Window3 : Window
    {
        public Window3()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (var context = new Context())
            {
                Author author = new Author()
                {
                    Name = TextBox1.Text,
                    Surname = TextBox2.Text,
                    Patronymic = TextBox3.Text,
                }; 
                context.authors.Add(author);
                context.SaveChanges();
            }
            this.Close();
        }
    }
}
