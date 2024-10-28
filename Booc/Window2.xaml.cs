using Booc.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Policy;
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
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Booc
{
    /// <summary>
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        public Window2()
        {
            InitializeComponent();
            WER();
        }
        public Window2(Bookstore bookstore)
        {
            InitializeComponent();
            Textbox1.Text = bookstore.NameBook;
            int i = bookstore.Number_of_pages;
            texbox4.Text = i.ToString();
            texbox7.Text = Convert.ToString(bookstore.Cost_price);
            texbox8.Text = Convert.ToString(bookstore.Price_for_sale);
            WER();
            ComboBox1.SelectedIndex = bookstore.authorId;
            ComboBox2.SelectedIndex = bookstore.publishersId;
            ComboBox3.SelectedIndex = bookstore.genreId;
            if (bookstore.TrilogiesId != 0)
            {
                ComboBox4.SelectedIndex = (int)bookstore.TrilogiesId;
            }
        }
        public void WER()
        {
            using (var context = new Context())
            {
                var res = context.authors.ToList();
                ComboBox1.ItemsSource = res;
                ComboBox1.DisplayMemberPath = "Name";
                ComboBox1.SelectedValuePath = "Id";
                var res1 = context.publishers.ToList();
                ComboBox2.ItemsSource = res1;
                ComboBox2.DisplayMemberPath = "Name";
                ComboBox2.SelectedValuePath = "Id";
                var res2 = context.genres.ToList();
                ComboBox3.ItemsSource = res2;
                ComboBox3.DisplayMemberPath = "Name";
                ComboBox3.SelectedValuePath = "Id";
                var res3 = context.trilogies.ToList();
                ComboBox4.ItemsSource = res3;
                ComboBox4.DisplayMemberPath = "Name";
                ComboBox4.SelectedValuePath = "Id";
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Bookstore bookstore;
            if (ComboBox4.SelectedItem != null)
            {
                using (var context = new Context())
                {
                    bookstore = new Bookstore()
                    {
                        NameBook = Textbox1.Text,
                        author = context.authors.Where(p => p.Id == (int)ComboBox1.SelectedValue).First(),
                        authorId = (int)ComboBox1.SelectedValue,
                        publishers = context.publishers.Where(p => p.Id == (int)ComboBox2.SelectedValue).First(),
                        publishersId = (int)ComboBox2.SelectedValue,
                        Number_of_pages = Convert.ToInt32(texbox4.Text),
                        genre = context.genres.Where(p => p.Id == (int)ComboBox3.SelectedValue).First(),
                        genreId = (int)ComboBox3.SelectedIndex,
                        DateTime = (DateTime)DatePicker1.SelectedDate,
                        Cost_price = Convert.ToInt32(texbox7.Text),
                        Price_for_sale = Convert.ToInt32(texbox8.Text),
                        trilogies = context.trilogies.Where(p => p.Id == (int)ComboBox4.SelectedValue).First(),
                        TrilogiesId = (int)ComboBox4.SelectedIndex,
                    };
                    context.bookstore.Add(bookstore);
                    context.SaveChanges();
                }
            }
            else
            {
                //NewTrilogies(Textbox1.Text);
                
                using (var context = new Context())
                {
                    var trilogiess = context.trilogies.FirstOrDefault(p => p.Name == Textbox1.Text);
                    bookstore = new Bookstore()
                    {
                        NameBook = Textbox1.Text,
                        author = context.authors.Where(p => p.Id == (int)ComboBox1.SelectedValue).First(),
                        authorId = (int)ComboBox1.SelectedValue,
                        publishers = context.publishers.Where(p => p.Id == (int)ComboBox2.SelectedValue).First(),
                        publishersId = (int)ComboBox2.SelectedValue,
                        Number_of_pages = Convert.ToInt32(texbox4.Text),
                        genre = context.genres.Where(p => p.Id == (int)ComboBox3.SelectedValue).First(),
                        genreId = (int)ComboBox3.SelectedIndex,
                        DateTime = (DateTime)DatePicker1.SelectedDate,
                        Cost_price = Convert.ToInt32(texbox7.Text),
                        Price_for_sale = Convert.ToInt32(texbox8.Text),
                        //trilogies = context.trilogies.Where(p => p.Name == Textbox1.Text).First(),
                        trilogies = null,
                        TrilogiesId = null,
                    };
                    context.bookstore.Add(bookstore);
                    context.SaveChanges();
                }


            }
            this.Close();
        }
        public void NewTrilogies(string str)
        {
            using (var context = new Context())
            {
                Trilogies trilogies = new Trilogies()
                {
                    Name = str,
                };
                context.trilogies.Add(trilogies);
                context.SaveChanges();
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            Window3 window3 = new Window3();
            window3.ShowDialog();
            ComboBox1.ItemsSource = null; 
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            Window4 window3 = new Window4();
            window3.ShowDialog();
            ComboBox1.ItemsSource = null;
        }
        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            Window5 window3 = new Window5();
            window3.ShowDialog();
            ComboBox1.ItemsSource = null;
        }
        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            Window6 window3 = new Window6();
            window3.ShowDialog();
            ComboBox1.ItemsSource = null;
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            WER();
        }
    }
}
