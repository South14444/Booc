using Booc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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
    /// Логика взаимодействия для Window7.xaml
    /// </summary>
    public partial class Window7 : Window
    {
        public Window7(Account account)
        {
            InitializeComponent();
            DataGrid1Wre();
            if (account.Status == "Full")
            {
                FormFull();
            }
        }
        public void FormFull()
        {
            Label label = new Label
            {
                Content = "Списать:",
                Width = 100
            }; 
            Canvas.SetLeft(label, 639); 
            Canvas.SetTop(label, 150);  
            MainCanvas.Children.Add(label);

            TextBox textBox = new TextBox
            {
                Width = 200
            };
            Canvas.SetLeft(textBox, 639); 
            Canvas.SetTop(textBox, 180);  
            MainCanvas.Children.Add(textBox);


            Button button = new Button
            {
                Content = "Списать",
                Width = 100
            };
            Canvas.SetLeft(button, 639); 
            Canvas.SetTop(button, 220);  
            button.Click += (s, e) => OnWriteOffClick(textBox);
            MainCanvas.Children.Add(button);
            Label label1 = new Label
            {
                Content = "Новая Скидка:",
                Width = 100
            };
            Canvas.SetLeft(label1, 639);
            Canvas.SetTop(label1, 250);
            MainCanvas.Children.Add(label1);

            TextBox textBox1 = new TextBox
            {
                Width = 200
            };
            Canvas.SetLeft(textBox1, 639);
            Canvas.SetTop(textBox1, 280);
            MainCanvas.Children.Add(textBox1);


            Button button1 = new Button
            {
                Content = "Новая Скидка",
                Width = 100
            };
            Canvas.SetLeft(button1, 639);
            Canvas.SetTop(button1, 320);
            button1.Click += (s, e) => OnWriteOffClick2(textBox1);
            MainCanvas.Children.Add(button1);
        }
        private void OnWriteOffClick2(TextBox textBox1)
        {
            int text = 0;
            if (textBox1 != null)
            {
                text = Convert.ToInt32(textBox1.Text);
            }
            if (DataGrid1.SelectedItem != null)
            {
                var res = DataGrid1.SelectedItem as Warehouse;
                if (res.Discount > text)
                {
                    int Id = res.Id;

                    using (var context = new Context())
                    {
                        var book = context.warehouses.Find(Id);
                        if (book != null)
                        {
                            book.Discount = res.Discount - text;
                            context.SaveChanges();
                        }
                    }
                }
            }

        }
        private void OnWriteOffClick(TextBox textBox)
        {
            int text = 0;
            if (textBox != null)
            {
                text = Convert.ToInt32(textBox.Text);
            }
            if (DataGrid1.SelectedItem != null)
            {
                var res = DataGrid1.SelectedItem as Warehouse;
                if (res.Quantity > text)
                {
                    int Id=res.Id;

                    using (var context = new Context())
                    {
                        var book = context.warehouses.Find(Id);
                        if (book != null)
                        {
                            book.Quantity = res.Quantity-text; 
                            context.SaveChanges();
                        }
                    }
                }
            }

        }
        public void DataGrid1Wre()
        {
            using (var context = new Context())
            {
                DataGrid1.ItemsSource = null;

                var bookstores = context.warehouses
                    .Include(p => p.bookstore)
                    .ToList();
                DataGrid1.ItemsSource = bookstores;
            }
        }
        private void DataGrid1_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            var hiddenColumns = new List<string> { "Id", "BookstoreId" };
            if (hiddenColumns.Contains(e.PropertyName))
            {
                e.Cancel = true;
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int text = 0;
            if (TextBox != null)
            {
                text = Convert.ToInt32(TextBox.Text);
            }
            if (DataGrid1.SelectedItem != null)
            {
                var res = DataGrid1.SelectedItem as Warehouse;
                if (res.Quantity > text)
                {
                    int Id = res.Id;

                    using (var context = new Context())
                    {
                        var book = context.warehouses.Find(Id);
                        if (book != null)
                        {
                            book.Quantity = res.Quantity - text;
                            context.SaveChanges();
                        }
                    }
                }
            }
        }
    }
}
