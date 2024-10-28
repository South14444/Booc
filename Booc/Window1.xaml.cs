using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Booc.Models;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client.NativeInterop;
using Account = Booc.Models.Account;

namespace Booc
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Account _account;
        public Window1(Account account)
        {
            InitializeComponent();
            DataGrid1Wre();
            _account = account;
        }

        public void DataGrid1Wre()
        {
            using (var context = new Context())
            {
                DataGrid1.ItemsSource = null;

                var bookstores = context.bookstore
                    .Include(p => p.author)
                    .Include(p => p.publishers)
                    .Include(p => p.genre)
                    .Include(p => p.trilogies)
                    .ToList();
                DataGrid1.ItemsSource = bookstores;
            }
        }
        private void DataGrid1_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var hiddenColumns = new List<string> { "Id", "authorId", "genreId", "publishersId" };
            if (hiddenColumns.Contains(e.PropertyName))
            {
                e.Cancel = true;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.ShowDialog();
            DataGrid1Wre();
        }
        private void Button_Click3(object sender, RoutedEventArgs e)
        {
            string sMessageBoxText = "Вы уверены, что хотите удалить книгу?";
            string sCaption = "Подтверждение удаления";

            MessageBoxButton btnMessageBox = MessageBoxButton.YesNoCancel;
            MessageBoxImage icnMessageBox = MessageBoxImage.Warning;

            MessageBoxResult rsltMessageBox = MessageBox.Show(sMessageBoxText, sCaption, btnMessageBox, icnMessageBox);

            switch (rsltMessageBox)
            {
                case MessageBoxResult.Yes:
                    Bookstore bookstore = new Bookstore();
                    var res = DataGrid1.SelectedItem as Bookstore;

                    if (res != null)
                    {
                        using (var context = new Context())
                        {
                            var itemToDelete = context.bookstore.FirstOrDefault(item => item.NameBook == res.NameBook);
                            if (itemToDelete != null)
                            {
                                context.bookstore.Remove(itemToDelete);
                                context.SaveChanges();
                            }
                        }
                    }
                    break;

                case MessageBoxResult.No:
                    break;

                case MessageBoxResult.Cancel:
                    break;
            }
            DataGrid1Wre();
        }
        private void Button_Click2(object sender, RoutedEventArgs e)
        {
            DataGrid1Wre();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (DataGrid1.SelectedItem != null)
            {
                var res = DataGrid1.SelectedItem as Bookstore;
                Window2 window2 = new Window2(res);
                window2.Show();
            }
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            Window7 window7 = new Window7(_account);
            window7.Show();
            this.Close();
        }
    }
}
