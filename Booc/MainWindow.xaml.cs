using Booc.Models;
using System;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Booc
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //using (var context = new Context())
            //{
            //    Account account = new Account()
            //    {
            //        Name = "Лев144",
            //        Surname = "Кравченко144",
            //        Patronymic = "Алексеевич144",
            //        Email = "144",
            //        Password = "144",
            //        Status = "Full"
            //    };
            //    context.Account.Add(account);
            //    context.SaveChanges();
            //}
            //using (var context = new Context())
            //{
            //    Account account = new Account()
            //    {
            //        Name = "Иван",
            //        Surname = "Иванов",
            //        Patronymic = "Иванов",
            //        Email = "2",
            //        Password = "2",
            //        Status = "User"
            //    };
            //    context.Account.Add(account);
            //    context.SaveChanges();
            //}
            //using (var context = new Context())
            //{
            //    Genre genre = new Genre()
            //    {
            //        Name = "Roman",
            //    };
            //    Genre genre1 = new Genre()
            //    {
            //        Name = "Proza",
            //    };
            //    context.genres.Add(genre);
            //    context.genres.Add(genre1);
            //    context.SaveChanges();
            //}
            //using (var context = new Context())
            //{
            //    Trilogies trilogies = new Trilogies()
            //    {
            //        Name = "1"
            //    };
            //    context.trilogies.Add(trilogies);
            //    context.SaveChanges();
            //}
            //using (var context = new Context())
            //{
            //    Publishers publishers = new Publishers()
            //    {
            //        Name = "OOO.PVO",
            //    };
            //    Publishers publishers1 = new Publishers()
            //    {
            //        Name = "OOO.TOO",
            //    };
            //    context.publishers.Add(publishers);
            //    context.publishers.Add(publishers1);
            //    context.SaveChanges();
            //}
            string Email = TextBox1.Text;
            string Password = TextBox2.Text;

            using (var context = new Context())
            {
                var res = context.Account
                    .Where(p => p.Email == Email && p.Password == Password)
                    .FirstOrDefault();
                if (res != null)
                {
                    if (res.Status == "Full")
                    {
                        Window1 applications = new Window1(res);
                        applications.Show();
                        this.Close();
                    }
                    else
                    {
                        Window1 window1 = new Window1(res);
                        window1.Show();
                        this.Close();
                    }
                }
                else
                {
                    MessageBox.Show("Аккаунт не найден или неправильный пароль.");
                }
            }
        }
    }
}